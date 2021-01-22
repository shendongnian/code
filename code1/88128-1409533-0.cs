    // Bind to GUI
    ArrayList dsList;
    dgvName.DataSource = dsList;
    dgvName.DataBind();
    
    // Slightly simpler way of getting code from GUI
    int iRow = 0;
    foreach (DataGridViewRow dgvr in gvName.Rows)
    {    
        object item = dgvr.DataBoundItem;        
        dsList[iRow].D1 = item.ToString();
      
        iRow++;
    }
