    TabPage pg = tabControl1.SelectedTab;
    
    // Get all the controls here
    Control.ControlCollection col = pg.Controls;
    
    // should have only one dgv
    foreach (Control myControl in col)
    {
        if (myControl.ToString() == "System.Windows.Forms.DataGridView")
        {
            DataGridView tempdgv = (DataGridView)myControl;   
            tempdgv.SelectAll();
        }
    }
