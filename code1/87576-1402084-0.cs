    public partial class ReportViewer : DevExpress.XtraEditors.XtraForm
    {
        public ReportViewer()
        {
            InitializeComponent();
        }
        // Used when displaying a single report
        public void SetReport(XtraReport report)
        {
            this.printControl.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
            this.printControl.UpdatePageView();
        }
        // Used when displaying merged reports
        public void SetReport(PrintingSystem system)
        {
            this.printControl.PrintingSystem = system;
            this.printControl.UpdatePageView();
        }
    }
