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
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            CancellationToken cToken = tokenSource.Token;
            cToken.Register(() => cancelNotification());
            var task = Task.Run(() =>
            {
                // do some heavy work here
                GenerateReport(sender, cToken);
            }, cToken);
            task.ContinueWith(result => finishReport(result));
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
        private static void finishReport(Task result)
        {
            if(result.IsCanceled)
            {
                cancelNotification();
            }
            else
            {
                //do stuff when the task is completted
            }
        }
    }
