    private void BTN_Save_Click(object sender, EventArgs e)
    {
        using (SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(da))
        {
            try
            {
                da.Update(ds, "DATEaTable1");
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message.Substring(0, Math.Min(ex.Message.Length, 1024));
                MessageBox.Show(ErrorMsg);
            }
        }
    }
