    var nowPlusOneWeek = DateTime.Now + new TimeSpan(7, 0, 0, 0);
    var expiringItems = InventoryList.Rows.Cast<DataGridViewRow>().
        Where(x => x.Cells[0].Value != null && Convert.ToDateTime(x.Cells[3].Value.ToString()) <= nowPlusOneWeek);
    var Expiry = new StringBuilder();
    foreach (var item in expiringItems)
        Expiry.Append("Nearing Expiry: " + item.Cells[0].Value.ToString() + "\n");
    MessageBox.Show(Expiry.ToString());
