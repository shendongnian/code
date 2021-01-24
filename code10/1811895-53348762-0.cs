    private void removeProxiesButton_Click(object sender, EventArgs e)
    {
        using (var conn = new SQLiteConnection(Properties.Settings.Default.dbConnectionString))
        {
            conn.Open();
            var sb = new StringBuilder();
            sb.Append("DELETE FROM Proxy WHERE ProxyID IN (");
    
            foreach (DataGridViewRow row in proxiesDataGridView.SelectedRows)
            {
                var proxy = proxies[row.Index];
                sb.Append(proxy.ProxyID + ",");
            }
            sb[sb.Length - 1] = ')';
            using (var cmd = new SQLiteCommand(sb.ToString(), conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
