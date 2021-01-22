    [STAThread]
    static void Main() 
    {
       System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(ReportError);
       System.Windows.Forms.Application.Run(new MainForm());
    }
    private static void ReportError(object sender, ThreadExceptionEventArgs e)
    {
       using (ReportErrorDialog errorDlg = new ReportErrorDialog(e.Exception))
       {
        errorDlg.ShowDialog();
       }
    }
