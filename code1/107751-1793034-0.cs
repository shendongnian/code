    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace HostLibrary
    {
        public struct TestInfo
        {
            [MarshalAs(UnmanagedType.BStr)]
            public string label;
            [MarshalAs(UnmanagedType.I4)]
            public int count;
        }
        [ComVisible(true)]
        public interface ITestSender
        {
            int hostwindow {get; set;}
            void DoTest(string someParameter);
        }
        [ComVisible(true)]
        public class TestSender : ITestSender
        {
            public TestSender()
            {
                m_HostWindow = IntPtr.Zero;
                m_count = 0;
            }
            IntPtr m_HostWindow;
            int m_count;
    #region ITestSender Members
            public int hostwindow { 
                get { return (int)m_HostWindow; } 
                set { m_HostWindow = (IntPtr)value; } }
                
            public void DoTest(string strParameter)
            {
                m_count++;
                TestInfo inf;
                inf.label = strParameter;
                inf.count = m_count;
                IntPtr lparam = IntPtr.Zero;
                try
                {
                    lparam = Marshal.AllocHGlobal(Marshal.SizeOf(inf));
                    Marshal.StructureToPtr(inf, lparam, false);
                    // WM_APP is 0x8000
                    IntPtr retval = SendMessage(
                        m_HostWindow, 0x8000, IntPtr.Zero, lparam);
                }
                finally
                {
                    if (lparam != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure(lparam, typeof(TestInfo));
                        Marshal.FreeHGlobal(lparam);
                    }
                }
            }
    #endregion
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            extern public static IntPtr SendMessage(
                IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam);
        }
    }
