    [WebMethod]
        public Dictionary<string, List<string>> getProgram12Months(string usersessionid)
        {
            Dictionary<string, List<string>> dict = new   Dictionary<string, List<string>>();
      
            List<string> labels = new List<string>();
    
            //First get distinct Month Name for select Year.
            string query1 = "SELECT DISTINCT TOP (100) PERCENT TimeFrame FROM dbo.CSQ_ProgramCount12Months ORDER BY TimeFrame ";
    
            string conn = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            SqlDataAdapter dap = new SqlDataAdapter(query1, conn);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            DataTable dtLabels = ds.Tables[0];
    
    
            foreach (DataRow drow in dtLabels.Rows)
            {
                labels.Add(drow["TimeFrame"].ToString());
            }
            //Here add your labels list with labels key name
            dict.Add("labels", labels);
            //Add more list to above dictionary with unique key.
            
            return dict;
        }
