    foreach (var item in upcList)
        {
            try
            {
                if (!string.IsNullOrEmpty(item[0]))
                {
                    string upc;
                    if (DropCheckDigit != true)
                    {
                        upc = Helpers.upc.formatBRDUpc(item[0]);
                    }
                    else
                    {
                        upc = Helpers.upc.formatBRDUpcDropCheckDigit(item[0]);
                    }
                    using (BRDataDb db = new BRDataDb())
                    {
                        var results = db.Database.SqlQuery<ProductMovementItem>("EXEC MoC_MoCHub_GetItemData @p0, @p1", upc, DataSource).FirstOrDefault();
                        if (results != null)
                        {
                            if (results.BaseQty != 0 && results.BasePrice != 0)
                            {
                                results.Margin = (((results.BasePrice / results.BaseQty) - results.cost) / (results.BasePrice / results.BaseQty)) * 100;
                                if (results.Margin != null)
                                {
                                    results.Margin = decimal.Round(decimal.Parse(results.Margin.ToString()), 2);
                                }
                            }
                            PMIList.Add(results);
                            progressCounter += 1;
                            Helpers.SharedFunctions.SendProgress("Processing...", progressCounter, (upcList.Count * 2), connectionId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
        }
