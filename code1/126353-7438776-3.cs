    public delegate void LinkToEventHandler();
    public partial class frmDL : Form
    {
        public static event LinkToEventHandler Evt;
        public frmDL()
        {
            InitializeComponent();
        }
        public static void SendEvent()
        {
            if (Evt != null)
            {
                Evt();
            }
        }
        private void btnEvent_Click(object sender, EventArgs e)
        {
            SendEvent();
        }
    }
}
