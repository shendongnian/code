    private void HookCallbackInner(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0)
                {
                    if (wParam == (IntPtr)InterceptKeys.WM_KEYDOWN)
                    {
                        int vkCode = Marshal.ReadInt32(lParam);
    
                        if (KeyDown != null)
                            KeyDown(this, new RawKeyEventArgs(vkCode, false));
                    }
                }
            }
    
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using FileManagerLibrary.Objects;
    
    namespace FileCommandManager
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            readonly KeyboardListener _kListener = new KeyboardListener();
            private DispatcherTimer tm;
    
            private void Application_Startup(object sender, StartupEventArgs e)
            {
                _kListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);
            }
    
            private List<Key> _keysPressedIntowSecound = new List<Key>();
            private void TmBind()
            {
                tm = new DispatcherTimer();
                tm.Interval = new TimeSpan(0, 0, 2);
                tm.IsEnabled = true;
                tm.Tick += delegate(object sender, EventArgs args)
                {
                    tm.Stop();
                    tm.IsEnabled = false;
                    _keysPressedIntowSecound = new List<Key>();
                };
                tm.Start();
            }
    
            void KListener_KeyDown(object sender, RawKeyEventArgs args)
            {
                var text = args.Key.ToString();
                var m = args;
                _keysPressedIntowSecound.Add(args.Key);
                if (tm == null || !tm.IsEnabled)
                    TmBind();
            }
    
            private void Application_Exit(object sender, ExitEventArgs e)
            {
                _kListener.Dispose();
            }
        }
    }
