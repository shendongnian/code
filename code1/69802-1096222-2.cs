    public partial class MyTextBox : TextBox
    {
        int WM_LBUTTONDOWN = 0x0201; //513
        int WM_LBUTTONUP = 0x0202; //514
        int WM_LBUTTONDBLCLK = 0x0203; //515
        public MyTextBox()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || 
               m.Msg == WM_LBUTTONUP || 
               m.Msg == WM_LBUTTONDBLCLK // && Your State To Check
               )
            {
                //Dont dispatch message
                return;
            }
            base.WndProc(ref m);
        }
    }
