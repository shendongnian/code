    public partial class Contact : Page
    {
        private static CancellationTokenSource tokenSource = new CancellationTokenSource();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected async void btnExportExcel_Click(object sender, EventArgs e)
        {
            CancellationToken cToken = tokenSource.Token;
            cToken.Register(() => cancelNotification());
            try
            {
                await Task.Run(() =>
                {
                    cToken.ThrowIfCancellationRequested();
                    GenerateReport(sender, cToken);
                }, cToken);
            }
            catch(OperationCanceledException)
            {
            }
        }
        private void GenerateReport(object sender, CancellationToken ct)
        {
            // Just to Simulate Export to excel
            Thread.Sleep(70000);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }
        private static void cancelNotification()
        {
            // Do your stuff when the user is canceld the report generation
        }
    }
