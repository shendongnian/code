              Public IEnumerable setFilter(TEntity entity 
                       ,func<IQueryable<bool 
                       out,TEntity)> where 
                            =null , func<IQueryable<TEntity> 
                      ,IOrderedQueryable<TEntity>> order =null)
                     {
                          IQueryable query = entity;
                          If(whrer != null)
                            {
                               query =query.where(where);
                             }
                              If(order != null)
                            {
                               query =Order(query);
                             }
                            Return query.toList();
                      }
