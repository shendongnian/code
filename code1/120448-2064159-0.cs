    static class Program
    {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.AddMessageFilter(new MouseMessageFilter());
            MouseMessageFilter.MouseMove += new MouseEventHandler(OnGlobalMouseMove);
    
            Application.Run(new MainForm());
        }
    
        static void OnGlobalMouseMove(object sender, MouseEventArgs e) {
            Console.WriteLine(e.Location.ToString());
        }
    
    
    
    }
    
    class MouseMessageFilter : IMessageFilter
    {
        public static event MouseEventHandler MouseMove = delegate { }; 
        const int WM_MOUSEMOVE = 0x0200;
    
        public bool PreFilterMessage(ref Message m) {
    
            if (m.Msg == WM_MOUSEMOVE) {
                
                Point mousePosition = Control.MousePosition;
                
                MouseMove(null, new MouseEventArgs(
                    MouseButtons.None, 0, mousePosition.X, mousePosition.Y,0));
            }
    
            return false;
        }
    }
