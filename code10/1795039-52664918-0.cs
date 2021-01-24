    using System;
    using System.Windows.Forms;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ReportDocument cryRpt = new ReportDocument();
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables ;
    
                cryRpt.Load("PUT CRYSTAL REPORT PATH HERE\CrystalReport1.rpt");
    
                crConnectionInfo.ServerName = "YOUR SERVER NAME";
                crConnectionInfo.DatabaseName = "YOUR DATABASE NAME";
                crConnectionInfo.UserID = "YOUR DATABASE USERNAME";
                crConnectionInfo.Password = "YOUR DATABASE PASSWORD";
    
                CrTables = cryRpt.Database.Tables ;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }
    
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh(); 
            }
        }
    }
