    public void PrintHiredEmployeesMethod()
        {
           
            //set Processing Mode of Report as Local  
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //set path of the Local report  
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/rptAllEmployeeRecord.rdlc");
            //Passing Parameter
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("paramHeader", "HIRED EMPLOYEES REPORT"));
            this.ReportViewer1.LocalReport.SetParameters(reportParameters);
            //creating object of DataSet dsEmployee and filling the DataSet using SQLDataAdapter  
            DataSetAllEmployee dsemp = new DataSetAllEmployee();
            using (SqlConnection con = new SqlConnection(Base.GetConnection))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM TableEmployee WHERE Status=@Status", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Status","HIRED");
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(dsemp, "dtAllEmployeeRecord");
            }
            //Providing DataSource for the Report  
            ReportDataSource rds = new ReportDataSource("DataSetAllEmployee", dsemp.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            //Add ReportDataSource  
            ReportViewer1.LocalReport.DataSources.Add(rds);
        }
