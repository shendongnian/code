    public partial class ListItem: UserControl
    {
        private const int WM_MOUSEACTIVATE = 0x0021;
        protected override void WndProc(ref Message m)
        {
            if(m.Msg == WM_MOUSEACTIVATE)
            {
                Debug.Print("Activated!");
            }
            base.WndProc(ref m);
        }
    }
