        public Form1()
        {
            InitializeComponent();
            txtAuto.Enter +=txtAuto_Enter;
            txtAuto.Leave +=txtAuto_Leave;
        }
        private void txtAC_Enter(object sender, EventArgs e)
        {
            AcceptButton = null;
            CancelButton = null;
        }
        private void txtAC_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }
