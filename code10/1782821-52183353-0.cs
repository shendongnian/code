    private void LoadGroupSummary()
    {
        try
        { 
            if (Session["GroupSummary"] != null)
            {
                dt = (DataTable)Session["GroupSummary"];
            }
            else
            {
                UserBLL userBLL = new UserBLL();
                dt = userBLL.GetGroupSummary(2, 2017);
                Session["GroupSummary"] = dt;                    
            }
            gvGroupSummary.DataSource = dt;
            gvGroupSummary.DataBind();
        }
        catch (SqlException ex)
        {
              System.Console.Error.Write(ex.Message);
        }
    }
