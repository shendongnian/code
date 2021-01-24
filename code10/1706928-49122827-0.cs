    namespace WMS.Presentation
    {
        public partial class frmCustomers : Form
        {
    
            Form newCustomer = new frmNewCustomer();
    
            public frmCustomers()
            {
                InitializeComponent();
    			
    			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormClosing);
            }
    
    
            private void btnNewCustomer_Click(object sender, EventArgs e)
            {
                if (newCustomer.IsDisposed)
                    newCustomer = new frmNewCustomer();
    
                newCustomer.MdiParent = this.MdiParent;
                newCustomer.Show();
                newCustomer.BringToFront();
            }
    		
    		private void FormClosing(object sender, EventArgs e)
            {
    			if (!newCustomer.IsDisposed)
    				newCustomer.Close();
    		}
        }
    }
