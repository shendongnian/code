    string sql = @"
        insert into barcodes
        values (default, :B1, :B2, :B3, :B4, :B5, :B6)
        returning barcode_id
    ";
    NpgsqlTransaction trans = conn.BeginTransaction();
    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn, trans);
    cmd.Parameters.Add(new NpgsqlParameter("B1", NpgsqlTypes.NpgsqlDbType.Text));
    cmd.Parameters.Add(new NpgsqlParameter("B2", NpgsqlTypes.NpgsqlDbType.Text));
    cmd.Parameters.Add(new NpgsqlParameter("B3", NpgsqlTypes.NpgsqlDbType.Text));
    cmd.Parameters.Add(new NpgsqlParameter("B4", NpgsqlTypes.NpgsqlDbType.Text));
    cmd.Parameters.Add(new NpgsqlParameter("B5", NpgsqlTypes.NpgsqlDbType.Text));
    cmd.Parameters.Add(new NpgsqlParameter("B6", NpgsqlTypes.NpgsqlDbType.Text));
    foreach (Barcode b in barcodes)
    {
        cmd.Parameters[0].Value = b.Barcode1;
        cmd.Parameters[1].Value = b.Barcode2;
        cmd.Parameters[2].Value = b.Barcode3;
        cmd.Parameters[3].Value = b.Barcode4;
        cmd.Parameters[4].Value = b.Barcode5;
        cmd.Parameters[5].Value = b.Barcode6;
        b.BarcodeId = Convert.ToInt32(cmd.ExecuteScalar());
    }
    trans.Commit();
