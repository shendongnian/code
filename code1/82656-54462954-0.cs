    /// <summary>
    /// Pins an array of Blittable structs so that we can access the data as bytes. Manages a GCHandle around the array.
    /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.unsafeaddrofpinnedarrayelement?view=netframework-4.7.2
    /// </summary>
    public sealed class PinnedArray<T> : IDisposable
    {
        public GCHandle Handle { get; }
        public T[] Array { get; }
        public int ByteCount { get; private set; }
        public IntPtr Ptr { get; private set; }
        
        public IntPtr ElementPointer(int n)
        {
            return Marshal.UnsafeAddrOfPinnedArrayElement(Array, n);
        }
        public PinnedArray(T[] xs)
        {
            Array = xs;
            // This will fail if the underlying type is not Blittable (e.g. not contiguous in memory)
            Handle = GCHandle.Alloc(xs, GCHandleType.Pinned);
            if (xs.Length != 0)
            {
                Ptr = ElementPointer(0);
                ByteCount = (int) Ptr.Distance(ElementPointer(Array.Length));
            }
            else
            {
                Ptr = IntPtr.Zero;
                ByteCount = 0;
            }
        }
        void DisposeImplementation()
        {
            if (Ptr != IntPtr.Zero)
            {
                Handle.Free();
                Ptr = IntPtr.Zero;
                ByteCount = 0;
            }
        }
        ~PinnedArray()
        {
            DisposeImplementation();
        }
        public void Dispose()
        {
            DisposeImplementation();
            GC.SuppressFinalize(this);
        }
    }
IMHO Working with PInvoke and IntPtr is as dangerous as marking your assembly as unsafe and using pointers in an unsafe context (if not more) 
If you don't mind unsafe blocks you can write extension functions that operate on the `IntPtr` cast to `byte*` like the following:
    public static long Distance(this IntPtr a, IntPtr b)
    {
         return Math.Abs(((byte*)b) - ((byte*)a));
    }
However, like always you have to be aware of possible alignment issues when casting to different pointer types.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.unsafeaddrofpinnedarrayelement?view=netframework-4.7.2
  [2]: https://github.com/ara3d/ara3d-dev/blob/master/dotnet/Utilities/PinnedArray.cs
