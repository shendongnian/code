    public HttpResponseMessage Gets(DataSourceLoadOptions loadOptions)
            {
                var sorgu = (from c in db.company
                            join d in db.driver
                            on c.Guid equals d.CompanyId
                            orderby c.Guid descending
                            select new { Guid= d.Guid, Name=c.Name, });
                return Request.CreateResponse(DataSourceLoader.Load(sorgu.ToList(), loadOptions));
            }
