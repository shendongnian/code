    dt = GetStationeryConsolidationDetails(txtRefNo.Text);
    int intRows = dt.Rows.Count;
    int x = 0;
    for (int c = 0; c < intRows; c++)
    {
      if (dt.Rows[c - x]["DQTY"].ToString() == "0")
      {
        dt.Rows[c - x].Delete();
        dt.AcceptChanges();
        x++;        
      }
    }
