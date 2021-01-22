    private List<string> mAllianceList = new List<string>();
    private BindingList<string> bindingList;    
    private void FillAllianceList()
    {
        // Add alliance name to member alliance list
        foreach (Village alliance in alliances)
        {
            mAllianceList.Add(alliance.AllianceName);
        }
    
        bindingList = new BindingList<string>(mAllianceList);
        
        // Bind alliance combobox to alliance list
        this.cboAlliances.DataSource = bindingList;
    }
