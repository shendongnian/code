    Listbox1.Items.Clear();
    MAcon.Open();
    OleDbDataAdapter da = new OleDbDataAdapter("Select Process from [Product Family] Where [Product Name] = @ProductName", MAcon);
    da.SelectCommand.Parameters.AddWithValue("@ProductName", ItemCBx.SelectedItem.ToString());
    DataTable dtbl = new DataTable();
    da.Fill(dtbl);
    ListBox2.DataSource = dtbl;
    
    ListBox2.DisplayMember = "Process ";
    ListBox2.ValueMember = "Process";
    MAcon.Close();
    Listbox2.Show();    
                listBox2.Text.ToString().Split(',').ToList().ForEach(r => Listbox1.Items.Add(r.Trim()));
    
    //       
