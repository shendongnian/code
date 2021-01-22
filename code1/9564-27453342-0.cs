    static class Examples
    {
        static void Example1_SafeUserToken()
        {
            const string user = "SomeLocalUser";
            const string domain = null;
            const string password = "ExamplePassword";
            NativeMethods.SafeTokenHandle userToken;
            WindowsIdentity identity;
            NativeMethods.LogonUser(user, domain, password, NativeMethods.LogonType.LOGON32_LOGON_INTERACTIVE, NativeMethods.LogonProvider.LOGON32_PROVIDER_DEFAULT, out userToken);
            using (userToken)
            {
                // get a WindowsIdentity object for the user
                // WindowsIdentity will duplicate the token, so it is safe to free the original token after this is called
                identity = userToken.GetWindowsIdentity();
            }
            // impersonate the user
            using (identity)
            using (WindowsImpersonationContext impersonationContext = identity.Impersonate())
            {
                Console.WriteLine("I'm running as {0}!", Thread.CurrentPrincipal.Identity.Name);
            }
        }
        static void Example2_SafeLocalAllocWStrArray()
        {
            const string commandLine = "/example /command";
            int argc;
            string[] args;
            using (NativeMethods.SafeLocalAllocWStrArray argv = NativeMethods.CommandLineToArgvW(commandLine, out argc))
            {
                // CommandLineToArgvW returns NULL on failure; since SafeLocalAllocWStrArray inherits from
                // SafeHandleZeroOrMinusOneIsInvalid, it will see this value as invalid
                // if that happens, throw an exception containing the last Win32 error that occurred
                if (argv.IsInvalid)
                {
                    int lastError = Marshal.GetHRForLastWin32Error();
                    throw new Win32Exception(lastError, "An error occurred when calling CommandLineToArgvW.");
                }
                // the one unsafe aspect of this is that the developer calling this function must be trusted to
                // pass in an array of length argc or specify the length of the copy as the value of argc
                // if the developer does not do this, the array may end up containing some garbage or an
                // AccessViolationException could be thrown
                args = new string[argc];
                argv.CopyTo(args);
            }
            for (int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine("Argument {0}: {1}", i, args[i]);
            }
        }
    }
    /// <summary>
    /// P/Invoke methods and helper classes used by this example.
    /// </summary>
    internal static class NativeMethods
    {
        // documentation: http://msdn.microsoft.com/en-us/library/windows/desktop/aa378184(v=vs.85).aspx
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, LogonType dwLogonType, LogonProvider dwLogonProvider, out SafeTokenHandle phToken);
        // documentation: http://msdn.microsoft.com/en-us/library/windows/desktop/ms724211(v=vs.85).aspx
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);
        // documentation: http://msdn.microsoft.com/en-us/library/windows/desktop/bb776391(v=vs.85).aspx
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SafeLocalAllocWStrArray CommandLineToArgvW(string lpCmdLine, out int pNumArgs);
        // documentation: http://msdn.microsoft.com/en-us/library/windows/desktop/aa366730(v=vs.85).aspx
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LocalFree(IntPtr hLocal);
        /// <summary>
        /// Wraps a handle to a user token.
        /// </summary>
        public class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            /// <summary>
            /// Creates a new SafeTokenHandle. This constructor should only be called by P/Invoke.
            /// </summary>
            private SafeTokenHandle()
                : base(true)
            {
            }
            /// <summary>
            /// Creates a new SafeTokenHandle to wrap the specified user token.
            /// </summary>
            /// <param name="arrayPointer">The user token to wrap.</param>
            /// <param name="ownHandle"><c>true</c> to close the token when this object is disposed or finalized,
            /// <c>false</c> otherwise.</param>
            public SafeTokenHandle(IntPtr handle, bool ownHandle)
                : base(ownHandle)
            {
                this.SetHandle(handle);
            }
            /// <summary>
            /// Provides a <see cref="WindowsIdentity" /> object created from this user token. Depending
            /// on the type of token, this can be used to impersonate the user. The WindowsIdentity
            /// class will duplicate the token, so it is safe to use the WindowsIdentity object created by
            /// this method after disposing this object.
            /// </summary>
            /// <returns>a <see cref="WindowsIdentity" /> for the user that this token represents.</returns>
            /// <exception cref="InvalidOperationException">This object does not contain a valid handle.</exception>
            /// <exception cref="ObjectDisposedException">This object has been disposed and its token has
            /// been released.</exception>
            public WindowsIdentity GetWindowsIdentity()
            {
                if (this.IsClosed)
                {
                    throw new ObjectDisposedException("The user token has been released.");
                }
                if (this.IsInvalid)
                {
                    throw new InvalidOperationException("The user token is invalid.");
                }
                return new WindowsIdentity(this.handle);
            }
            /// <summary>
            /// Calls <see cref="NativeMethods.CloseHandle" /> to release this user token.
            /// </summary>
            /// <returns><c>true</c> if the function succeeds, <c>false otherwise</c>. To get extended
            /// error information, call <see cref="Marshal.GetLastWin32Error"/>.</returns>
            protected override bool ReleaseHandle()
            {
                return NativeMethods.CloseHandle(this.handle);
            }
        }
        /// <summary>
        /// A wrapper around a pointer to an array of Unicode strings (LPWSTR*) using a contiguous block of
        /// memory that can be freed by a single call to LocalFree.
        /// </summary>
        public sealed class SafeLocalAllocWStrArray : SafeLocalAllocArray<string>
        {
            /// <summary>
            /// Creates a new SafeLocalAllocWStrArray. This constructor should only be called by P/Invoke.
            /// </summary>
            private SafeLocalAllocWStrArray()
                : base(true)
            {
            }
            /// <summary>
            /// Creates a new SafeLocalallocWStrArray to wrap the specified array.
            /// </summary>
            /// <param name="handle">The pointer to the unmanaged array to wrap.</param>
            /// <param name="ownHandle"><c>true</c> to release the array when this object
            /// is disposed or finalized, <c>false</c> otherwise.</param>
            public SafeLocalAllocWStrArray(IntPtr handle, bool ownHandle)
                : base(ownHandle)
            {
                this.SetHandle(handle);
            }
            /// <summary>
            /// Returns the Unicode string referred to by an unmanaged pointer in the wrapped array.
            /// </summary>
            /// <param name="index">The index of the value to retrieve.</param>
            /// <returns>the value at the position specified by <paramref name="index" /> as a string.</returns>
            protected override string GetArrayValue(int index)
            {
                return Marshal.PtrToStringUni(Marshal.ReadIntPtr(this.handle + IntPtr.Size * index));
            }
        }
        // This class is similar to the built-in SafeBuffer class. Major differences are:
        // 1. This class is less safe because it does not implicitly know the length of the array it wraps.
        // 2. The array is read-only.
        // 3. The type parameter is not limited to value types.
        /// <summary>
        /// Wraps a pointer to an unmanaged array of objects that can be freed by calling LocalFree.
        /// </summary>
        /// <typeparam name="T">The type of the objects in the array.</typeparam>
        public abstract class SafeLocalAllocArray<T> : SafeHandleZeroOrMinusOneIsInvalid
        {
            /// <summary>
            /// Creates a new SafeLocalArray which specifies that the array should be freed when this
            /// object is disposed or finalized.
            /// <param name="ownsHandle"><c>true</c> to reliably release the handle during the finalization phase;
            /// <c>false</c> to prevent reliable release (not recommended).</param>
            /// </summary>
            protected SafeLocalAllocArray(bool ownsHandle)
                : base(ownsHandle)
            {
            }
            /// <summary>
            /// Converts the unmanaged object referred to by <paramref name="valuePointer" /> to a managed object
            /// of type T.
            /// </summary>
            /// <param name="index">The index of the value to retrieve.</param>
            /// <returns>the value at the position specified by <paramref name="index" /> as a managed object of
            /// type T.</returns>
            protected abstract T GetArrayValue(int index);
            // 
            /// <summary>
            /// Frees the wrapped array by calling LocalFree.
            /// </summary>
            /// <returns><c>true</c> if the call to LocalFree succeeds, <c>false</c> if the call fails.</returns>
            protected override bool ReleaseHandle()
            {
                return (NativeMethods.LocalFree(this.handle) == IntPtr.Zero);
            }
            /// <summary>
            /// Copies the unmanaged array to the specified managed array.
            /// 
            /// It is important that the length of <paramref name="array"/> be less than or equal to the length of
            /// the unmanaged array wrapped by this object. If it is not, at best garbage will be read and at worst
            /// an exception of type <see cref="AccessViolationException" /> will be thrown.
            /// </summary>
            /// <param name="array">The managed array to copy the unmanaged values to.</param>
            /// <exception cref="ObjectDisposedException">The unmanaged array wrapped by this object has been
            /// freed.</exception>
            /// <exception cref="InvalidOperationException">The pointer to the unmanaged array wrapped by this object
            /// is invalid.</exception>
            /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
            public void CopyTo(T[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException("array");
                }
                this.CopyTo(array, 0, array.Length);
            }
            /// <summary>
            /// Copies the unmanaged array to the specified managed array.
            /// 
            /// It is important that <paramref name="length" /> be less than or equal to the length of
            /// the array wrapped by this object. If it is not, at best garbage will be read and at worst
            /// an exception of type <see cref="AccessViolationException" /> will be thrown.
            /// </summary>
            /// <param name="array">The managed array to copy the unmanaged values to.</param>
            /// <param name="index">The index to start at when copying to <paramref name="array" />.</param>
            /// <param name="length">The number of items to copy to <paramref name="array" /></param>
            /// <exception cref="ObjectDisposedException">The unmanaged array wrapped by this object has been
            /// freed.</exception>
            /// <exception cref="InvalidOperationException">The pointer to the unmanaged array wrapped by this object
            /// is invalid.</exception>
            /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or- 
            /// <paramref name="index" /> is greater than the length of <paramref name="array"/>.-or-
            /// <paramref name="length"/> is less than zero.</exception>
            /// <exception cref="ArgumentException">The sum of <paramref name="index" /> and <paramref name="length" />
            /// is greater than the length of <paramref name="array" />.</exception>
            public void CopyTo(T[] array, int index, int length)
            {
                if (this.IsClosed)
                {
                    throw new ObjectDisposedException(this.ToString());
                }
                if (this.IsInvalid)
                {
                    throw new InvalidOperationException("This object's buffer is invalid.");
                }
                if (array == null)
                {
                    throw new ArgumentNullException("array");
                }
                if (index < 0 || array.Length < index)
                {
                    throw new ArgumentOutOfRangeException("index", "index must be a nonnegative integer that is less than array's length.");
                }
                if (length < 0)
                {
                    throw new ArgumentOutOfRangeException("length", "length must be a nonnegative integer.");
                }
                if (array.Length < index + length)
                {
                    throw new ArgumentException("length", "length is greater than the number of elements from index to the end of array.");
                }
                for (int i = 0; i < length; ++i)
                {
                    array[index + i] = this.GetArrayValue(i);
                }
            }
        }
        /// <summary>
        /// The type of logon operation to perform.
        /// </summary>
        internal enum LogonType : uint
        {
            LOGON32_LOGON_BATCH = 1,
            LOGON32_LOGON_INTERACTIVE = 2,
            LOGON32_LOGON_NETWORK = 3,
            LOGON32_LOGON_NETWORK_CLEARTEXT = 4,
            LOGON32_LOGON_NEW_CREDENTIALS = 5,
            LOGON32_LOGON_SERVICE = 6,
            LOGON32_LOGON_UNLOCK = 7
        }
        /// <summary>
        /// The logon provider to use.
        /// </summary>
        internal enum LogonProvider : uint
        {
            LOGON32_PROVIDER_DEFAULT = 0,
            LOGON32_PROVIDER_WINNT50 = 1,
            LOGON32_PROVIDER_WINNT40 = 2
        }
    }
