    using System;
    using System.Windows.Forms;
    
    namespace Test
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            public static Form frm = null;
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frm = new Form1 {Opacity = 0.25};
                frm.Controls.Add(new Button{Dock = DockStyle.Fill, Text = "Ok"});
                
                Application.AddMessageFilter(new MouseMoveFilter());
                Application.Run(frm);
            }
        }
    
        public class MouseMoveFilter : IMessageFilter
        {
            #region IMessageFilter Members
            private const int WM_MOUSELEAVE     = 0x02A3;
            private const int WM_NCMOUSEMOVE    = 0x0A0;
            private const int WM_MOUSEMOVE      = 0x0200;
            private const int WM_NCMOUSELEAVE   = 0x2A2;
    
            public bool PreFilterMessage(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_NCMOUSEMOVE:
                    case WM_MOUSEMOVE:
                        Program.frm.Opacity = 1;
                        break;
    
                    case WM_NCMOUSELEAVE:
                    case WM_MOUSELEAVE:
                        if (!Program.frm.Bounds.Contains(Control.MousePosition))
                            Program.frm.Opacity = 0.25;
                        break;
                        
                }
                return false;
            }
    
            #endregion
        }
    }
