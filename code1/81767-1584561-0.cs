                IQueryable<IncomeDetailsEntity> query;
                if (!string.IsNullOrEmpty(regioncode))
                {
                    if (!string.IsNullOrEmpty(compcode))
                    {
                        query = db.IncomeDetailsEntities.Where(i => i.RegionCode == regioncode && i.CompanyCode == compcode);
                    }
                    else
                    {
                        query = db.IncomeDetailsEntities.Where(i => i.RegionCode == regioncode);
                    }
                }
                else
                {
                    query = db.IncomeDetailsEntities;
                }
                return query.Select(i => new { i.RegionCode, i.Budget });
