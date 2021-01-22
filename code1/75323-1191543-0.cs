    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace TestKeydown
    {
        public class RegisterHotKeyClass
        {
            private IntPtr m_WindowHandle = IntPtr.Zero;
            private MODKEY m_ModKey = MODKEY.MOD_CONTROL;
            private Keys m_Keys = Keys.A;
            private int m_WParam = 10000;
            private bool Star = false;
            private HotKeyWndProc m_HotKeyWnd = new HotKeyWndProc();
    
            public IntPtr WindowHandle
            {
                get { return m_WindowHandle; }
                set { if (Star)return; m_WindowHandle = value; }
            }
            public MODKEY ModKey
            {
                get { return m_ModKey; }
                set { if (Star)return; m_ModKey = value; }
            }
            public Keys Keys
            {
                get { return m_Keys; }
                set { if (Star)return; m_Keys = value; }
            }
            public int WParam
            {
                get { return m_WParam; }
                set { if (Star)return; m_WParam = value; }
            }
    
            public void StarHotKey()
            {
                if (m_WindowHandle != IntPtr.Zero)
                {
                    if (!RegisterHotKey(m_WindowHandle, m_WParam, m_ModKey, m_Keys))
                    {
                        throw new Exception("");
                    }
                    try
                    {
                        m_HotKeyWnd.m_HotKeyPass = new HotKeyPass(KeyPass);
                        m_HotKeyWnd.m_WParam = m_WParam;
                        m_HotKeyWnd.AssignHandle(m_WindowHandle);
                        Star = true;
                    }
                    catch
                    {
                        StopHotKey();
                    }
                }
            }
            private void KeyPass()
            {
                if (HotKey != null) HotKey();
            }
            public void StopHotKey()
            {
                if (Star)
                {
                    if (!UnregisterHotKey(m_WindowHandle, m_WParam))
                    {
                        throw new Exception("");
                    }
                    Star = false;
                    m_HotKeyWnd.ReleaseHandle();
                }
            }
    
    
            public delegate void HotKeyPass();
            public event HotKeyPass HotKey;
    
    
            private class HotKeyWndProc : NativeWindow
            {
                public int m_WParam = 10000;
                public HotKeyPass m_HotKeyPass;
                protected override void WndProc(ref Message m)
                {
                    if (m.Msg == 0x0312 && m.WParam.ToInt32() == m_WParam)
                    {
                        if (m_HotKeyPass != null) m_HotKeyPass.Invoke();
                    }
    
                    base.WndProc(ref m);
                }
            }
    
            public enum MODKEY
            {
                MOD_ALT = 0x0001,
                MOD_CONTROL = 0x0002,
                MOD_SHIFT = 0x0004,
                MOD_WIN = 0x0008,
            }
    
            [DllImport("user32.dll")]
            public static extern bool RegisterHotKey(IntPtr wnd, int id, MODKEY mode, Keys vk);
    
            [DllImport("user32.dll")]
            public static extern bool UnregisterHotKey(IntPtr wnd, int id);
        }
    }
