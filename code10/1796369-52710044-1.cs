    MessageBox.Show(String.Format("{0}-{1}-{2}-{3}-{4}",
           id_order, row.Cells[0].Value, row.Cells[2].Value,  row.Cells[3].Value, row.Cells[4].Value));
    string query = "INSERT INTO \"ORDER_DETAIL\" (id_order, id_product, quantity, val_siva, iva) VALUES( @id_order, @id_product, @quantity, @val_siva, @iva);";
    using (var cn = new SqlConnection("connection string here"))
    using (var cmd = new SqlCommand(query, cn))
    {
        cmd.Parameters.Add("@id_order", SqlDbType.Int).Value = int.Parse(id_order);
        cmd.Parameters.Add("@id_product", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[0].Value);
        cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[2].Value);
        cmd.Parameters.Add("@val_siva", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[3].Value);
        cmd.Parameters.Add("@iva", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
        cn.Open();
        cmd.ExecuteNonQuery();
    }
