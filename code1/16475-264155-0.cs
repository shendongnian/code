    private void btnScenario2_Click(object sender, EventArgs e)
    {
    
        FrmDialog dlg = new FrmDialog();
        //Subscribe this form for callback
        dlg.AddItemCallback = new AddItemDelegate(this.AddItemCallbackFn);
        dlg.ShowDialog();
    
    }
    private void AddItemCallbackFn(string item)
    {
    
        lstBx.Items.Add(item);
    
    }
