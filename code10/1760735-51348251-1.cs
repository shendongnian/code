    private void ptrSTATUS_GRID_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
        ptrSTATUS.CommitEdit();
        using (SqlConnection con = new SqlConnection(GDC_ConnectionString))
        {
            con.Open();
            SqlCommandBuilder builder = new SqlCommandBuilder(sda););
            sda.Update(dtPTR_STATUS);
            con.Close();
        }
    }
