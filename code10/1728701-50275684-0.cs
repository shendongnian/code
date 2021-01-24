    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Constants.Constants;
    using Constants.Enums;
    using Models.WindowsApiModels;
    
    namespace Dependencies.MessagingHandling
    {
        public class CustomWindow : IDisposable
        {
            delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    
    
            private const int ErrorClassAlreadyExists = 1410;
            public IntPtr Handle { get; private set; }
            public List<YourType> Messages { get; set; }
    
            public void Dispose()
            {
                if (Handle != IntPtr.Zero)
                {
                    Importer.DestroyWindow(Handle);
                    Handle = IntPtr.Zero;
                }
            }
    
            public CustomWindow()
            {
                Messages = new List<YourType>();
                var className = "Prototype Messaging Class";
    
                WndProc mWndProcDelegate = CustomWndProc;
    
                // Create WNDCLASS
                WNDCLASS windClass = new WNDCLASS
                {
                    lpszClassName = className,
                    lpfnWndProc = Marshal.GetFunctionPointerForDelegate(mWndProcDelegate)
                };
    
                UInt16 classAtom = Importer.RegisterClassW(ref windClass);
    
                int lastError = Marshal.GetLastWin32Error();
    
                if (classAtom == 0 && lastError != ErrorClassAlreadyExists)
                {
                    throw new Exception("Could not register window class");
                }
    
                // Create window
                Handle = Importer.CreateWindowExW(
                    0,
                    className,
                    "Prototype Messaging Window",
                    0, 0, 0, 0, 0,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero
                );
            }
    
            private IntPtr  CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
            {
                //handle your message here
    
                return Importer.DefWindowProc(hWnd, msg, wParam, lParam);
            }
    
    
    
            public Task GetMessage()
            {
                IntPtr handle = Handle;
                int bRet;
                while ((bRet = Importer.GetMessage(out var msg, Handle, 0, 0)) != 0)
                {
                    switch (bRet)
                    {
                        case -1:
                            Console.WriteLine("Error");
                            CancellationToken token = new CancellationToken(true);
                            return Task.FromCanceled(token);
                        default:
                            Importer.TranslateMessage(ref msg);
                            Importer.DispatchMessage(ref msg);
                            break;
                    }
                }
                return Task.FromResult(true);
            }
        }
    }
