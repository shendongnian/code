     protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (GenerateValidation())
            {
                Hashtable ht = new Hashtable();
                ht.Add("SearchCriteria", GetSearchCriteria());
                DataTable Data = new DataTable();
                DataSet ds = new DataSet();
                ds = obj_DBUtility.GetDataSetByProcedure(ht, "PR_GET_EMPLOYEE_DETAILS_FOR_SALARY_GENERATE");
                Data = ds.Tables[0];
                DataTable dtData = salaryItemsService.GetAllPRSalaryItemsSrtForSalaryGenerate();
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Data.Columns.Add(dtData.Rows[i]["ITEM_NAME"].ToString());
                }
                Data.Columns.Add("Net Salary");
                gvSalaryGenerate.HeaderRow.Cells.Add("SL No", "Empoloyee Details", "Allowance", "Deduction");
                gvSalaryGenerate.DataSource = Data;
                gvSalaryGenerate.DataBind();
                DataLoadInGrid(dtData);
                SetButtonVisible();
            }
        }
        catch (Exception ex)
        {
            ReallySimpleLog.WriteLog(ex);
        }
    }
