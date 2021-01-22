            try
            {
                mHndActivatedDevice = MyNameSpace.Interop.Device.Device.ActivateDevice("Drivers\\BuiltIn\\SomeDriverName", IntPtr.Zero, 0, IntPtr.Zero);
            }
            catch(Exception exc)
                {
                    // you can get the last error like this:
                    int lastError =                   
                       System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                    Console.WriteLine("error:" + lastError.ToString());
                    // but it is also inside the exception, you can get it like this
                    Console.WriteLine((
                     (System.ComponentModel.Win32Exception)exc).NativeErrorCode.ToString());
                    Console.WriteLine(exc.ToString());
                }
        }
