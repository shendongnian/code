    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Data;
    namespace ConsoleApplication76
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
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
                Report report = new Report();
                report.progress = 50;
                report.type = ReportTypes.PROGRESS;
                backgroundWorker1.ReportProgress(50, report);
                DataTable dt = new DataTable();
                report.table = dt;
                report.type = ReportTypes.DATATABLE;
                backgroundWorker1.ReportProgress(50, report);
            }
     
            private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
               int progress = e.ProgressPercentage;
               Report report =  e.UserState as Report;
               switch (report.type)
               {
                   case ReportTypes.PROGRESS :
                      BeginInvoke((MethodInvoker)delegate
                      {
                        WriteStatusAndError("Query Completed");
                      });
                       break;
                   case ReportTypes.DATATABLE :
                       break;
               }
           }
        }
    }
