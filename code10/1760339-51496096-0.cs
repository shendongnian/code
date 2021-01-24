    public partial class Contact : Page
    {
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Token"] != null)
            {
                tokenSource = HttpContext.Current.Session["Token"] as CancellationTokenSource;
            }
            else
            {
                HttpContext.Current.Session.Add("Token", new CancellationTokenSource());
                tokenSource = HttpContext.Current.Session["Token"] as CancellationTokenSource;
            }
        }
        protected async void btnExportExcel_Click(object sender, EventArgs e)
        {
            CancellationToken cToken = tokenSource.Token;
            cToken.Register(() => cancelNotification());
            await Task.Run(() =>
            {
                // do some heavy work here
                GenerateReport(sender, cToken);
            }, cToken);
        }
        private void GenerateReport(object sender, CancellationToken ct)
        {
            // Just to Simulate Export to excel
            Thread.Sleep(7000);
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
