    List<classSanple> lst = new List<classSample>
    lst.Add(...) //Add various instances of classSample
    BindingSource thisIsABindingSource = new BindingSource();
    thisIsABindingSource.DataSource = lst;
    reportDataSource rds = new ReportDataSource("prj_folder_classSample", thisIsABindingSource);
    
    ReportViewer1.ProcessingMode = ProcessingMode.Local;
    ReportViewer1.LocalReport.EnableExternalImages = true;
    ReportViewer1.LocalReport.ReportEmbeddedResource = "YourProject.Folder.reportName.rdlc";
    ReportViewer1.LocalReport.DataSources.Add(rds)
