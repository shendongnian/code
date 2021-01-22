    var insInvoice = new NpgsqlCommand(...);
    insInvoice.Parameters.With(p => {
        p.Add("_invoice_id", NpgsqlDbType.Uuid, 0, "invoice_id");
        ...
    });
