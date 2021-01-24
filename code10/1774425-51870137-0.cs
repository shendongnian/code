     var cpaclassids = FetchProductTypes(ids);
     var cpaclids = string.Join(",", cpaclassids);            
     var query = (from x in partJoinTableRepository.GetPartJoinQuery() join y in partRepository.GetPartsQuery() on x.PartId equals y.Id
                                          join z in partProductTypeReposiotry.GetPartProductTypesQuery() on x.PartId equals z.PartId where y.IsSkipped == 0 && (y.IsDisabled != "Y" || y.IsDisabled == null) && z.CreatedDate == x.CreatedDate && x.CreatedDate == Convert.ToDateTime(fromDate) select x).Cast<PartJoinTable>();
     var predicate1 = PredicateBuilder.True(query);
     predicate1 = predicate1.And(x => cpaclassids.Contains(x.ProductTypeId.ToString()));
     int lst = query.Where(predicate1).Select(x => x.PartId).Distinct().ToList().Count();
