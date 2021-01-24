    using(SqlConnetion....)
    {
        con.Open();
        using(SqlDataAdapter da ....)
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            //I use this method often because every change i am doing is directly into database and then i just refresh dgv if i need it by loading data again.
        }
    }
