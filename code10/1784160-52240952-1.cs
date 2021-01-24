    using(var context = new DatabaseContext())
        {
                var categoryIdParameter = new SqlParameter("@p0", categoryID);
                var pageIndexParameter = new SqlParameter("@p1", pageIndex);
                var pageSizeParameter = new SqlParameter("@p2", Common.PAGE_SIZE);
    
                var result = context.Database
                    .SqlQuery<ProductResult>("GetProductsByCategory @p0, @p1, @p2", categoryIdParameter, pageIndexParameter, pageSizeParameter)
                    .ToList();
        }
