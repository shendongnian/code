    //with(var p = insInvoice.Parameters)
    {
      var p = insInvoice.Parameters;
      p.Add("_invoice_id", NpgsqlDbType.Uuid, 0, "invoice_id");
      p.Add("_invoice_detail_id", NpgsqlDbType.Uuid, 0, "invoice_detail_id");
      p.Add("_product_id", NpgsqlDbType.Uuid, 0, "product_id");
      p.Add("_qty", NpgsqlDbType.Integer, 0, "qty");
      p.Add("_price", NpgsqlDbType.Numeric, 0, "price");
    }
