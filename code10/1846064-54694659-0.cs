    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult qustion = MessageBox.Show("Are you Sure to Deleted this Record ","Message Deleted",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
        if (qustion == DialogResult.Yes)
        {
            if (conn.Entry(otable).State == EntityState.Detached)
                MessageBox.Show("the sata is :"+ conn.Entry(otable).State);
            conn.tableUserinfoes.Attach(otable);
            conn.tableUserinfoes.Remove(otable);
            conn.SaveChanges();
            selectTable();
        }
    }
