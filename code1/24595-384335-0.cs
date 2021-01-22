    var insInvoice = new NpgsqlCommand(sql)
    {
        Parameters = 
        {
            { "_invoice_id", NpgsqlDbType.Uuid, 0, "invoice_id" },
            { "_invoice_detail_id", NpgsqlDbType.Uuid, 0, "invoice_detail_id" },
            { "_qty", NpgsqlDbType.Integer, 0, "qty" },
            { "_price", NpgsqlDbType.Numeric, 0, "price" }
        }
    };
