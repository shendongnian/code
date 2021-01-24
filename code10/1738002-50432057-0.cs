        var query = from d in dtmaster.AsEnumerable()
                    join c in dtitems.AsEnumerable() on d.Field<string>("ReceiptId") equals c.Field<string>("ReceiptId")
                    .Select(new
                    {
                        ReceiptId = d.Field<string>("ReceiptId")
                    });
