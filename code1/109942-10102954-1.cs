        private void PrepareReport(ViewTravelOrderEmployees travelOrder)
        {
            entities = new PNEntities();            
            this.mform_components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ProductBindingSource = new System.Windows.Forms.BindingSource(this.mform_components);
            this.ProductBindingSource2 = new System.Windows.Forms.BindingSource(this.mform_components);            
            reportDataSource1.Name = "ViewTravelOrderEmployees";
            reportDataSource1.Value = this.ProductBindingSource;
            //DAL_Destination is Subreport -> Properties -> General -> Name in rdlc
            reportDataSource2.Name = "DAL_Destinations";
            reportDataSource2.Value = this.ProductBindingSource2;
            this.reprt.LocalReport.DataSources.Add(reportDataSource1);
            this.reprt.LocalReport.DataSources.Add(reportDataSource2);
            this.reprt.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);            
            this.reprt.LocalReport.ReportEmbeddedResource = "PNWPF.TravelOrder.rdlc";
            string exeFolder = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            string reportPath = System.IO.Path.Combine(exeFolder, @"Reports\TravelOrder.rdlc");
            this.reprt.LocalReport.ReportPath = reportPath;
            this.ProductBindingSource.DataSource = travelOrder;            
            this.reprt.RefreshReport();             
        }
            void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            entities = new PNEntities();
            string dataSourceName = e.DataSourceNames[0];
            //query needs to be completed this is just example
            List<Destinations> destinations = entities.Destinations.ToList();            
            
            e.DataSources.Add(new ReportDataSource(dataSourceName, destinations));
        }
        PNEntities entities;
        private System.ComponentModel.IContainer mform_components = null;
        private System.Windows.Forms.BindingSource ProductBindingSource;
        private System.Windows.Forms.BindingSource ProductBindingSource2;
