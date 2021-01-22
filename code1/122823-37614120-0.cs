    foreach (RivWorks.Model.Negotiation.AutoNegotiationDetails companyFeedDetail in companyFeedDetailList)
                    {
    private RivWorks.Model.Negotiation.RIV_Entities _dbRiv = RivWorks.Model.Stores.RivEntities(AppSettings.RivWorkEntities_connString);
                        if (companyFeedDetail.FeedSourceTable.ToUpper() == "AUTO")
                        {
                            var company = (from a in _dbRiv.Company.Include("Product") where a.CompanyId == companyFeedDetail.CompanyId select a).First();
                            foreach (RivWorks.Model.NegotiationAutos.Auto sourceProduct in client.Auto)
                            {
                                foreach (RivWorks.Model.Negotiation.Product targetProduct in company.Product)
                                {
                                    if (targetProduct.alternateProductID == sourceProduct.AutoID)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (!found)
                                {
                                    var newProduct = new RivWorks.Model.Negotiation.Product();
                                    newProduct.alternateProductID = sourceProduct.AutoID;
                                    newProduct.isFromFeed = true;
                                    newProduct.isDeleted = false;
                                    newProduct.SKU = sourceProduct.StockNumber;
                                    company.Product.Add(newProduct);
                                }
                            }
                            _dbRiv.SaveChanges();  // ### THIS BREAKS ### //
                        }
                    }
