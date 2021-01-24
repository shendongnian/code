    for (int i = 0; i < newDt.Rows.Count; i++)
    {
        var soldQty = Convert.ToInt32(newDt.Rows[i]["qty"]);
        var batchId = Convert.ToInt32(newDt.Rows[i]["batch_num"]);
        SqlCommand command = new SqlCommand("update batch set sold_qty=@soldqty2, left_qty = Quantiy - @soldqty2 where id=@id2", con);
        command.Parameters.AddWithValue("@soldqty2", soldQty);
        command.Parameters.AddWithValue("@id2", batchId );
        rexe = command.ExecuteNonQuery();
    }
