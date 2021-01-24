        public enum ReportTypes
        {
            PROGRESS,
            DATATABLE
        }
        public class Report
        {
            public int progress { get; set; }
            public ReportTypes type { get; set; }
            public DataTable table { get; set; }
        }
        public class Worker
        {
            public BackgroundWorker backgroundWorker1 { get; set; }
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
            }
            private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                Report report = new Report();
                report.progress = 50;
                report.type = ReportTypes.PROGRESS;
                backgroundWorker1.ReportProgress(50,report);
                DataTable dt = new DataTable();
                report.table = dt;
                report.type = ReportTypes.DATATABLE;
                backgroundWorker1.ReportProgress(50,report);
            }
            private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
               int progress = e.ProgressPercentage;
               Report report =  e.UserState as Report;
               switch (report.type)
               {
                   case ReportTypes.PROGRESS :
                       break;
                   case ReportTypes.DATATABLE :
                       break;
               }
           }
        }
