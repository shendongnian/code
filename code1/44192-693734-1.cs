                var groupQuery = (from g in context.Groups
                            where g.GroupKey == 6 
                            select g).OfType<Deal>(); 
                
                var groups = groupQuery.ToList();
                foreach (var g in groups)
                {
                    // Assuming Dealcontract is an Object, not a Collection of Objects
                    g.DealContractReference.Load();
                    if (g.DealContract != null)
                    {
                        foreach (var d in g.DealContract)
                        {
                            // If the Reference is to a collection, you can just to a Straight ".Load"
                            //  if it is an object, you call ".Load" on the refence instead like with "g.DealContractReference" above
                            d.Contracts.Load();
                            foreach (var c in d.Contracts)
                            {
                                c.AdvertiserAccountType1Reference.Load();
                                // etc....
                            }
                        }
                    }
                }
