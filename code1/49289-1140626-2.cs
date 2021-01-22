            try
            {
                mHndActivatedDevice = MyNameSpace.Interop.Device.Device.ActivateDevice("Drivers\\BuiltIn\\SomeDriverName", IntPtr.Zero, 0, IntPtr.Zero);
            }
            catch(System.ComponentModel.Win32Exception exc) // as suggested by 
                {
                    // you can get the last error like this:
                    int lastError =                   
                       System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                    Console.WriteLine("error:" + lastError.ToString());
                    // but it is also inside the exception, you can get it like this
                    Console.WriteLine(exc.NativeErrorCode.ToString());
                    Console.WriteLine(exc.ToString());
                }
        }
