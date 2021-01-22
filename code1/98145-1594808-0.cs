    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            var bw = new BackgroundWorker();
            bw.DoWork += ExecuteOperations;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerAsync();
        }
        catch (Exception ex)
        {
            tb_LogBox.AppendText(Environment.NewLine + " =@= " + ex.Message + " " + ex.Source);
        }
    }
    private static void ExecuteOperations(object sender, DoWorkEventArgs e)
    {
        var FuncCall = new LogTimer();
        string text = Environment.NewLine + FuncCall.DnT();
        (sender as BackgroundWorker).ReportProgress(0, text);
    }
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        tb_LogBox.AppendText(e.UserState as string);
    }
    
    public class LogTimer
    {
        public string DnT()
        {
            const string datePat = @"d/MM/yyyy";
            var dateTime = DateTime.Now;
            return dateTime.ToString(datePat);
        }
    }
