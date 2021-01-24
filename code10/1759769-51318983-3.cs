    public partial class Contact : Page
    {
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Cart"] != null)
            {
                tokenSource = HttpContext.Current.Session["Cart"] as CancellationTokenSource;
            }
            else
            {
                HttpContext.Current.Session.Add("Cart", new CancellationTokenSource());
                tokenSource = HttpContext.Current.Session["Cart"] as CancellationTokenSource;
            }
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            CancellationToken cToken = tokenSource.Token;
            cToken.Register(() => cancelNotification());
            Task.Factory.StartNew(() =>
            {
            // do some heavy work here
            GenerateReport(sender, cToken);
                if (cToken.IsCancellationRequested)
                {
                // another thread decided to cancel
                return;
                }
            }, cToken);
        }
        private void GenerateReport(object sender, CancellationToken ct)
        {
            var students = _context.Students.ToList();
            var courses = _context.Courses.ToList();
            var teachers = _context.Teachers.ToList();
            // Todo: Use above data to Generate Excel Report
            // Just to Simulate Export to excel
            Thread.Sleep(7000);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }
        private static void cancelNotification()
        {
            // Why never called ?
        }
    }
