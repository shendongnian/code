    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    
    namespace SecurityUtils
    {
        public partial class Strings
        {
            /// <summary>
            /// Passes decrypted password String pinned in memory to Func delegate scrubbed on return.
            /// </summary>
            /// <typeparam name="T">Generic type returned by Func delegate</typeparam>
            /// <param name="action">Func delegate which will receive the decrypted password pinned in memory as a String object</param>
            /// <returns>Result of Func delegate</returns>
            public static T DecryptSecureString<T>(SecureString secureString, Func<string, T> action)
            {
                var insecureStringPointer = IntPtr.Zero;
                var insecureString = String.Empty;
                var gcHandler = GCHandle.Alloc(insecureString, GCHandleType.Pinned);
    
                try
                {
                    insecureStringPointer = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                    insecureString = Marshal.PtrToStringUni(insecureStringPointer);
    
                    return action(insecureString);
                }
                finally
                {
                    //clear memory immediately - don't wait for garbage collector
                    fixed(char* ptr = insecureString )
                    {
                        for(int i = 0; i < insecureString.Length; i++)
                        {
                            ptr[i] = '\0';
                        }
                    }
                    insecureString = null;
    
                    gcHandler.Free();
                    Marshal.ZeroFreeGlobalAllocUnicode(insecureStringPointer);
                }
            }
    
            /// <summary>
            /// Runs DecryptSecureString with support for Action to leverage void return type
            /// </summary>
            /// <param name="secureString"></param>
            /// <param name="action"></param>
            public static void DecryptSecureString(SecureString secureString, Action<string> action)
            {
                DecryptSecureString<int>(secureString, (s) =>
                {
                    action(s);
                    return 0;
                });
            }
        }
    }
