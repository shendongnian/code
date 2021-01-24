    var db = Db.Profiles;
    var buyingCompanies = ((SimpleQuery)db.BuyingCompany
                    .FindAll(db.BuyingCompany.u_seller_id ==  DefaultValues.SellingCompany_GuidStr))
                    .ToArray();
    IDictionary<string, object> dict = (IDictionary<string, object>)buyingCompanies;
    IEnumerable<object> values = dict.Select(m => m.Value);
