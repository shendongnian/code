    /// Copyright (C) 2010 Douglas Day
    /// All rights reserved.
    /// MIT-licensed: http://www.opensource.org/licenses/mit-license.php
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Security;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    
    namespace DDay.Base
    {
        public class SecureStringToStringMarshaler : IDisposable
        {
            #region Private Fields
    
            private string _String;
            private SecureString _SecureString;
            private GCHandle _GCH;
    
            #endregion
    
            #region Public Properties
    
            public SecureString SecureString
            {
                get { return _SecureString; }
                set
                {
                    _SecureString = value;
                    UpdateStringValue();
                }
            }
    
            public string String
            {
                get { return _String; }
                protected set { _String = value; }
            } 
    
            #endregion
    
            #region Constructors
    
            public SecureStringToStringMarshaler()
            {
            }
    
            public SecureStringToStringMarshaler(SecureString ss)        
            {
                SecureString = ss;
            }
    
            #endregion
    
            #region Private Methods
    
            void UpdateStringValue()
            {
                Deallocate();
    
                unsafe
                {
                    if (SecureString != null)
                    {
                        int length = SecureString.Length;
                        String = new string('\0', length);
    
                        _GCH = new GCHandle();
    
                        // Create a CER (Contrained Execution Region)
                        RuntimeHelpers.PrepareConstrainedRegions();
                        try { }
                        finally
                        {
                            // Pin our string, disallowing the garbage collector from
                            // moving it around.
                            _GCH = GCHandle.Alloc(String, GCHandleType.Pinned);
                        }
    
                        IntPtr stringPtr = IntPtr.Zero;
                        RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(
                            delegate
                            {
                                // Create a CER (Contrained Execution Region)
                                RuntimeHelpers.PrepareConstrainedRegions();
                                try { }
                                finally
                                {
                                    stringPtr = Marshal.SecureStringToBSTR(SecureString);
                                }
    
                                // Copy the SecureString content to our pinned string
                                char* pString = (char*)stringPtr;
                                char* pInsecureString = (char*)_GCH.AddrOfPinnedObject();
                                for (int index = 0; index < length; index++)
                                {
                                    pInsecureString[index] = pString[index];
                                }
                            },
                            delegate
                            {
                                if (stringPtr != IntPtr.Zero)
                                {
                                    // Free the SecureString BSTR that was generated
                                    Marshal.ZeroFreeBSTR(stringPtr);
                                }
                            },
                            null);
                    }
                }
            }
    
            void Deallocate()
            {            
                if (_GCH.IsAllocated)
                {
                    unsafe
                    {
                        // Determine the length of the string
                        int length = String.Length;
    
                        // Zero each character of the string.
                        char* pInsecureString = (char*)_GCH.AddrOfPinnedObject();
                        for (int index = 0; index < length; index++)
                        {
                            pInsecureString[index] = '\0';
                        }
    
                        // Free the handle so the garbage collector
                        // can dispose of it properly.
                        _GCH.Free();
                    }
                }
            } 
    
            #endregion
    
            #region IDisposable Members
    
            public void Dispose()
            {
                Deallocate();
            }
    
            #endregion
        }
    }
