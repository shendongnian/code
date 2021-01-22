        // *********************************************************************
        // [DCOM Productions]
        // [Copyright (C) DCOM Productions All rights reserved.]
        //  >> Courtesy of Dave Anderson, DCOM Productions
        // *********************************************************************
        /// <summary>
        /// Security routines related to the Windows Key on a standard personal computer Keyboard
        /// </summary>
        public static class WindowsKey {
            /// <summary>
            /// Disables the Windows Key
            /// </summary>
            /// <remarks>May require the current user to logoff or restart the system</remarks>
            public static void Disable() {
                RegistryKey key = null;
                try {
                    key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout", true);
                    byte[] binary = new byte[] { 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x03, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x5B, 
                        0xE0, 
                        0x00, 
                        0x00, 
                        0x5C, 
                        0xE0, 
                        0x00, 
                        0x00, 
                        0x00, 
                        0x00 
                    };
                    key.SetValue("Scancode Map", binary, RegistryValueKind.Binary);
                }
                catch (System.Exception ex) {
                    Debug.Assert(false, ex.ToString());
                }
                finally {
                    key.Close();
                }
            }
            
            /// <summary>
            /// Enables the Windows Key
            /// </summary>
            /// <remarks>May require the current user to logoff or restart the system</remarks>
            public static void Enable() {
                RegistryKey key = null;
                try {
                    key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout", true);
                    key.DeleteValue("Scancode Map", true);
                }
                catch (System.Exception ex) {
                    Debug.Assert(false, ex.ToString());
                }
                finally {
                    key.Close();
                }
            }
        }
