    public void LoadData()
    {
           string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT T1.[ActivityID], T1.[Activity], T1.[ActivityRegisteredDate], T2.[Responsible], T3.[Category], T4.[Change_Requestor], T5.[Priority], T6.[Size], T7.[Status], T8.[System], T1.[Comment]" +
                    "FROM [BI_Planning].[dbo].[tlbActivity] T1 " +
                    "LEFT JOIN [BI_Planning].[dbo].[tblBI_Responsible] T2 ON T1.BI_ResponsibleID = T2.BI_ResponsibleID " +
                    "LEFT JOIN [BI_Planning].[dbo].[tblCategory] T3 ON T1.CategoryID = T3.CategoryID " +
                    "LEFT JOIN [BI_Planning].[dbo].[tblChange_Requestor] T4 ON T1.[ChangeRequestorID] = T4.[ChangeRequestorID] " +
                    "LEFT JOIN [BI_Planning].[dbo].[tblPriority] T5 ON T1.[PriorityID] = T5.[PriorityID] " +
                    "LEFT JOIN[BI_Planning].[dbo].[tblSize] T6 ON T1.[SizeID] = T6.[SizeID] " +
                    "LEFT JOIN [BI_Planning].[dbo].[tblStatus] T7 ON T1.[StatusID] = T7.[StatusID] " +
                    "LEFT JOIN [BI_Planning].[dbo].[tblSystem] T8 ON T1.[SystemID] = T8.[SystemID] " +
                    "ORDER BY T1.[ActivityRegisteredDate] desc", con);
                con.Open();
                gwActivity.DataSource = cmd.ExecuteReader();
                gwActivity.DataBind();
            }
    }
