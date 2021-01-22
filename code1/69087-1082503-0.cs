    public partial class frmInput : form
        {
            private frmMain mainFrame;
            public frmInput(frmMain parent)
            {
                mainFrame = parent;
                InitializeComponent();
    
                this.MdiParent = parent;
    
                //Of course I can do this
                Options options = mainFrame.options;
    
            }
           private void Something() {
              Options o = mainFrame.options; //can access options now.
           }
        }
