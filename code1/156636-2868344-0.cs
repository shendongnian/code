    namespace WindowsFormsApplication1
    {
        public class WebBrowserEx: System.Windows.Forms.WebBrowser
        {
            public void DoClick(int x, int y)
            {
                base.OnMouseClick(new MouseEventArgs(MouseButtons.Left, 1, x, y, 0));
            }
        }
    }
