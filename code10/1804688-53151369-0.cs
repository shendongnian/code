    DataFridView LoadDataToTab(ref DataTable dt, TabPage tab, TabControl Tab/*!*/, int tabIndex/*!*/)
    {    
        DataGridView grid   = new DataGridView();    
        BindingSource source = new BindingSource();    
        source.DataSource = dt;     
        grid.DataSource = source;    
    
        tab.Control.Add(grid);    
        // Now all binding is done;  
    
        // This TabControl Tab has inside TabPage tab 
        Tab.SelectedIndex = tabIndex; /*!*/
    
        // Now I need to hide some rows in TabPage-s:    
        HideSomeRows(ref grid);    
    
        return grid;    
    } 
        
    void HideSomeRows(ref DataGridView grid)
    {
        for (int i = 0; i < grid.Rows.Count; i++)
        {
            string val = grid.Rows[i].Cells[0].Value.ToString();
            // SomeString is some "xyz" stirng
            if( val == SomeString    ||
                val == SomeOtherString)
            {
                grid.Rows[i].Visible = false;
            }
        }
    }       
