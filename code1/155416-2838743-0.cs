    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                Application.AddMessageFilter(new TestMessageFilter());
                Application.Run(new Form1());
            }
        }
    
        public class TestMessageFilter : IMessageFilter
        {
            private int WM_SYSKEYDOWN = 0x0104;
            private int F4 = 0x73;
    
            public bool PreFilterMessage(ref Message i_Message)
            {
                Console.WriteLine("Msg: {0} LParam: {1} WParam: {2}", i_Message.Msg, i_Message.LParam, i_Message.WParam);
                if (i_Message.Msg == WM_SYSKEYDOWN && i_Message.WParam == (IntPtr)F4)
                    return (true); // Filter the message
                return (false);
            } // PreFilterMessage()
    
        } // class TestMessageFilter
    }
