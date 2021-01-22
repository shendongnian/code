    public void BuildListBoxes()
    {
        this.MyCurrentListBoxes = new List<ListBox>();
    
        for (int i = 0; i < this.HowManyListBoxesMyCustomerWants; i++)
        {
            ListBox lbx = new ListBox() { ... };
            this.MyCurrentListBoxes.Add(lbx);
            this.Controls.Add(lbx);
        }
    }
    
    public void BuildQuery()
    {
        List<string> queryParts = new List<string>();
    
        foreach (ListBox lbx in this.MyCurrentListBoxes)
        {
            if (this.IsCheckBoxCheckedFor(lbx))
            {
                queryParts.Add(this.GetFieldNameFor(lbx) + "=" + lbx.SelectedValue);
            }
        }
    
        string query = String.Join(" AND ", queryParts.ToArray());
    
        this.ExecuteQuery(query);
    }
