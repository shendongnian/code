    Listbox1.Items.Clear();
    MAcon.Open();
    OleDbDataAdapter da = new OleDbDataAdapter("Select Process from [Product Family] Where [Product Name] = @ProductName", MAcon);
    da.SelectCommand.Parameters.AddWithValue("@ProductName", ItemCBx.SelectedItem.ToString());
    DataTable dtbl = new DataTable();
    da.Fill(dtbl);
    ListBox1.DataSource = dtbl;
    
    ListBox1.DisplayMember = "Process ";
    ListBox1.ValueMember = "Process";
    MAcon.Close();
    Listbox1.Show();    
    //           Define.SelectedIndex = 1;
