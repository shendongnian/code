    using(DBConnect db = new DBConnect())
    {
        String q = "your sql Statement here";
        MySqlCommand cmd = new MySqlCommand(q, db.con);
        cmd.ExecuteNonQuery();
        MessageBox.Show("Item added", "Done", MessageBoxButtons.OK,mesageBoxIcon.Information);
                    }
