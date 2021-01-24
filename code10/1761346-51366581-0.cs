    var invoices = await dbConnection.QueryAsync<Invoices>("sp_get_invoices",
                        new 
                        {
                            InvoiceId = filter.InvoiceId,
                            Currency = filter.Currency
                        }, commandType: CommandType.StoredProcedure);
