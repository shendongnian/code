    private void checkListService_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        CheckedListBox box = sender as CheckedListBox;
            if (box != null)
            {
                var con = new DBConnection();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM price", con.Connection);
                DataSet ds = new DataSet();
                da.Fill(ds, "service");
                var checkedItems = box.SelectedItems;
                var rows = ds.Tables["service"].Rows.AsQueryable().Cast<price>().ToList();
                foreach (var checkedItem in checkedItems)
                {
                    var rowsForCheckedItem = rows.Where(x => x.service == ((price)checkedItem).service);
                    foreach (var row in rowsForCheckedItem)
                    {
                        listBPrice.Items.Add(row.price);
                    }
                }
            }
    }
