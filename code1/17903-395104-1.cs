    frmOptions {
         public frmMain MainForm; MainForm.Result = "result"; }
    
    frmMain {
         public string Result;
         frmOptions.MainForm = this;
         frmOptions.ShowDialog();
         string r = this.Result; }
