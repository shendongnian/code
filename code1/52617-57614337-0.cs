    public class SecureStringContext : IDisposable
        {
         #region fields
          private GCHandle? _gcHandler = null;
          private string _insecureString = null;
          private IntPtr? _insecureStringPointer = null;
          private SecureString _secureString = null;      
         #endregion
    
         #region ctor
          public SecureStringContext(SecureString secureString)
          {
           DecryptSecureString(secureString);
          }
         #endregion
    
         #region methos
         /// <summary>
         /// Passes decrypted password String pinned in memory to Func delegate scrubbed on return.
         /// </summary>
         private string DecryptSecureString(SecureString secureString)
         {
           _secureString = secureString;
           _insecureStringPointer = IntPtr.Zero;
           _insecureString = String.Empty;
           _gcHandler = GCHandle.Alloc(_insecureString, GCHandleType.Pinned);
    
           _insecureStringPointer = Marshal.SecureStringToGlobalAllocUnicode(_secureString);
           _insecureString = Marshal.PtrToStringUni(_insecureStringPointer.GetValueOrDefault(IntPtr.Zero));
    
            return _insecureString;
            }
    
            private void WipeInsecureString()
            {
                //clear memory immediately - don't wait for garbage collector
                unsafe
                {
                    fixed (char* ptr = _insecureString)
                    {
                        for (int i = 0; i < _insecureString.Length; i++)
                        {
                            ptr[i] = '\0';
                        }
                    }
                }
                _insecureString = null;
            }
            #endregion
    
            #region properties
            public string InsecureString { get => _insecureString; }
            #endregion
    
            #region dispose
            public void Dispose()
            {
                //clear memory immediately - don't wait for garbage collector
                WipeInsecureString();
            }
            #endregion
        }
