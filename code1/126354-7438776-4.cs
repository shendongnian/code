    //Receiver
    using System;
    using System.Windows.Forms;
    namespace eTest
    {
        public partial class frmMain : Form
        {
            public frmMain()
            {
                InitializeComponent();
            }
            public void ReceiveEvent(int i)
            {
                MessageBox.Show("Event Received from Form: " + i.ToString());
            }
            private void btnNew_Click(object sender, EventArgs e)
            {
                int num = 0;
                int x = 0;
                num = Convert.ToInt32(txtForms.Text);
                for (x = 0; x < num; x++)
                {
                    frmDL f = new frmDL();
                    f.Evt += ReceiveEvent;
                    f.iID = x;
                    f.Text = x.ToString(); 
                    f.Show();
                    f.Activate();
                    Application.DoEvents();
                }
            }
        }
    }
    //Sender
    using System;
    using System.Windows.Forms;
    namespace eTest
    {
        public delegate void myEventHandler(int i);
        public partial class frmDL : Form
        {
            public event myEventHandler Evt;
            public int iID = 0;
            public frmDL()
            {
                InitializeComponent();
            }
            public void SendEvent()
            {
                if (Evt != null)
                {
                    Evt(this.iID);
                }
            }
            private void btnEvent_Click(object sender, EventArgs e)
            {
                SendEvent();
            }
        }
    }
