    public DataTable RetrieveDiagnosisCodes()
        {
            //string tableName = "tblDiagnosisCues";
            DataSet ds = new DataSet();
    		Datatable dt = null;
            //strSQL = "select * from " & tableName & " where effectivedate <= getdate() and (termdate >= getdate() or termdate is null)"
            string strSQL = "select tblDiagnosisCues.*, tblDiagnosisCategory.Description as CategoryDesc, tblDiagnosisSubCategory.Description as SubCategoryDesc " + "FROM dbo.tblDiagnosisCategory INNER JOIN " + "dbo.tblDiagnosisSubCategory ON dbo.tblDiagnosisCategory.Category = dbo.tblDiagnosisSubCategory.Category INNER JOIN " + "dbo.tblDiagnosisCues ON dbo.tblDiagnosisSubCategory.SubCategory = dbo.tblDiagnosisCues.SubCategoryID " + "where effectivedate <= getdate() and (termdate >= getdate() or termdate is null) order by tblDiagnosisCues.Description";
    		
    		using(SqlDataAdapter da = new SqlDataAdapter(strSQL, Settings.Default.CMOSQLConn))
    		{
    			da.Fill(ds);
    			
    			if (ds.Tables.Count > 0)
    			{
    				dt = ds.Tables[0];
    			}
    		}
                    
            return dt;
        }
