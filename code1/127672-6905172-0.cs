    /// <summary>
    /// I base class to provide a mechanism where <see cref="IDisposable.Dispose"/>
    /// will be called when the last reference count is released.
    /// 
    /// </summary>
    public abstract class DisposableComObject: IDisposable
    {
        #region Release Handler, ugly, do not look
        //You were warned.
        //This code is to enable us to call IDisposable.Dispose when the last ref count is released.
        //It relies on one things being true:
        // 1. That all COM Callable Wrappers use the same implementation of IUnknown.
        //What Release() looks like with an explit "this".
        private delegate int ReleaseDelegate(IntPtr unk);
        //GetFunctionPointerForDelegate does NOT prevent GC ofthe Delegate object, so we'll keep a reference to it so it's not GC'd.
        //That would be "bad".
        private static ReleaseDelegate myRelease = new ReleaseDelegate(Release);
        //This is the actual address of the Release function, so it can be called by unmanaged code.
        private static IntPtr myReleaseAddress = Marshal.GetFunctionPointerForDelegate(myRelease);
        //Get a Delegate that references IUnknown.Release in the CCW.
        //This is where we assume that all CCWs use the same IUnknown (or at least the same Release), since
        //we're getting the address of the Release method for a basic object.
        private static ReleaseDelegate unkRelease = GetUnkRelease();
        private static ReleaseDelegate GetUnkRelease()
        {
            object test = new object();
            IntPtr unk = Marshal.GetIUnknownForObject(test);
            try
            {
                IntPtr vtbl = Marshal.ReadIntPtr(unk);
                IntPtr releaseAddress = Marshal.ReadIntPtr(vtbl, 2 * IntPtr.Size);
                return (ReleaseDelegate)Marshal.GetDelegateForFunctionPointer(releaseAddress, typeof(ReleaseDelegate));
            }
            finally
            {
                Marshal.Release(unk);
            }
        }
        //Given an interface pointer, this will replace the address of Release in the vtable
        //with our own. Yes, I know.
        private static void HookReleaseForPtr(IntPtr ptr)
        {
            IntPtr vtbl = Marshal.ReadIntPtr(ptr);
            IntPtr releaseAddress = Marshal.ReadIntPtr(vtbl, 2 * IntPtr.Size);
            Marshal.WriteIntPtr(vtbl, 2 * IntPtr.Size, myReleaseAddress);
        }
        //Go and replace the address of CCW Release with the address of our Release
        //in all the COM visible vtables.
        private static void AddDisposeHandler(object o)
        {
            //Only bother if it is actually useful to hook Release to call Dispose
            if (Marshal.IsTypeVisibleFromCom(o.GetType()) && o is IDisposable)
            {
                //IUnknown has its very own vtable.
                IntPtr comInterface = Marshal.GetIUnknownForObject(o);
                try
                {
                    HookReleaseForPtr(comInterface);
                }
                finally
                {
                    Marshal.Release(comInterface);
                }
                //Walk the COM-Visible interfaces implemented
                //Note that while these have their own vtables, the function address of Release
                //is the same. At least in all observed cases it's the same, a check could be added here to
                //make sure the function pointer we're replacing is the one we read from GetIUnknownForObject(object)
                //during initialization
                foreach (Type intf in o.GetType().GetInterfaces())
                {
                    if (Marshal.IsTypeVisibleFromCom(intf))
                    {
                        comInterface = Marshal.GetComInterfaceForObject(o, intf);
                        try
                        {
                            HookReleaseForPtr(comInterface);
                        }
                        finally
                        {
                            Marshal.Release(comInterface);
                        }
                    }
                }
            }
        }
        //Our own release. We will call the CCW Release, and then if our refCount hits 0 we will call Dispose.
        //Note that is really a method int IUnknown.Release. Our first parameter is our this pointer.
        private static int Release(IntPtr unk)
        {
            int refCount = unkRelease(unk);
            if (refCount == 0)
            {
                //This is us, so we know the interface is implemented
                ((IDisposable)Marshal.GetObjectForIUnknown(unk)).Dispose();
            }
            return refCount;
        }
        #endregion
        /// <summary>
        /// Creates a new <see cref="DisposableComObject"/>
        /// </summary>
        protected DisposableComObject()
        {
            AddDisposeHandler(this);
        }
        /// <summary>
        /// Calls <see cref="Dispose"/> with false.
        /// </summary>
        ~DisposableComObject()
        {
            Dispose(false);
        }
        /// <summary>
        /// Override to dispose the object, called when ref count hits or during GC.
        /// </summary>
        /// <param name="disposing"><b>true</b> if called because of a 0 refcount</param>
        protected virtual void Dispose(bool disposing)
        {
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
