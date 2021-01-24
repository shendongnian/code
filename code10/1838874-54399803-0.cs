       class Hooker : IDisposable
        {
            int MouseHookHandle;
            int KeyboardHookHandle;
            HookProc MouseHookGCRootedDelegate;
            HookProc KeyboardHookGCRootedDelegate;
    ..
        public Hooker()
            {
               // HookEvents.RegisterItself();
                MouseHookGCRootedDelegate = MouseHook;
                KeyboardHookGCRootedDelegate = KeyboardHook;
            }
    
            void HookKeyboard(bool bHook)
            {
                if (KeyboardHookHandle == 0 && bHook)
                {
                    using (var mainMod = Process.GetCurrentProcess().MainModule)
                        KeyboardHookHandle = HookNativeDefinitions.SetWindowsHookEx(HookNativeDefinitions.WH_KEYBOARD_LL, KeyboardHookGCRootedDelegate, HookNativeDefinitions.GetModuleHandle(mainMod.ModuleName), 0);
    
                    //If the SetWindowsHookEx function fails.
                    if (KeyboardHookHandle == 0)
                    {
                        System.Windows.MessageBox.Show("SetWindowsHookEx Failed " + new Win32Exception(Marshal.GetLastWin32Error()));
                        return;
                    }
                }
                else if(bHook == false)
                {
                    Debug.Print("Unhook keyboard");
                    HookNativeDefinitions.UnhookWindowsHookEx(KeyboardHookHandle);
                    KeyboardHookHandle = 0;
                }
    
            }
