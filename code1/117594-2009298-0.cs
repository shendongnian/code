            DataTable dt = new DataTable();
            DataColumn dc = dt.Columns.Add();
            dc.ColumnName = "DataColumn1";
            dc = dt.Columns.Add();
            dc.ColumnName = "DataColumn2";
            dt.Rows.Add(new object[] { "Frank", 32 });
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1_DataTable1", dt));
            this.reportViewer1.RefreshReport();  
  
