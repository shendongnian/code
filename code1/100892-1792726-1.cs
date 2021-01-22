    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace CSMessageLibrary
    {
        [ComVisible(true)]
        public interface ITestSenderSimple
        {
            // NOTE: Can't use IntPtr because it isn't VB6-compatible
            int hostwindow { get; set;}
            void DoTest(int number);
        }
        [ComVisible(true)]
        public class TestSenderSimple : ITestSenderSimple
        {
            public TestSenderSimple()
            {
                m_HostWindow = IntPtr.Zero;
                m_count = 0;
            }
            IntPtr m_HostWindow;
            int m_count;
            #region ITestSenderSimple Members
            public int hostwindow 
            {
                get { return (int)m_HostWindow; } 
                set { m_HostWindow = (IntPtr)value; } 
            }
            public void DoTest(int number)
            {
                m_count++;
                // WM_APP is 0x8000 (32768 decimal)
                IntPtr retval = SendMessage(
                    m_HostWindow, 0x8000, (IntPtr)m_count, (IntPtr)number);
            }
            #endregion
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            extern public static IntPtr SendMessage(
              IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam);
        }
    }
