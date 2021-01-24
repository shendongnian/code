    public static List<Entity> GetAll(IOrganizationService service, QueryExpression query)
        {
            var entities = new List<Entity>();
            query.PageInfo = new PagingInfo();
            query.PageInfo.Count = 5000;
            query.PageInfo.PagingCookie = null;
            query.PageInfo.PageNumber = 1;
            var res = service.RetrieveMultiple(query);
            entities.AddRange(res.Entities);
            while (res.MoreRecords == true)
            {
                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = res.PagingCookie;
                res = service.RetrieveMultiple(query);
                entities.AddRange(res.Entities);
            }
            return entities;
        }
