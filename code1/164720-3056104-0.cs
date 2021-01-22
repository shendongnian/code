    private void GetEmpList()      
    {      
        List<string> disabledKeys = new List<string>();
        SqlDataReader dr = ToolsLayer.GetEmpList();      
      
        while (dr.Read())      
        {      
            EmpDropDown.Items.Add(new ListItem(
                dr["Title"].ToString(), dr["EmpKey"].ToString()));      
      
            if (dr["Status"].ToString() == "disabled")      
            {
                disabledKeys.Add(dr["EmpKey"].ToString());
            }      
        }
        
        dr.Close();
        ViewState["DisabledKeys"] = disabledKeys;
    }  
