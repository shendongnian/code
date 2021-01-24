    [WebMethod]
        public object[] getProgram12Months(string usersessionid)
        {
            List<object> iData = new List<object>();
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
            iData.Add(labels.ToArray());
    
            return iData.ToArray();
        }
