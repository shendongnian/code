    using (var db = new TopicContext())
    {
        // build the query
        var query =
            from r in db.Result
            join t in db.Topic on r.TopicId equals t.Id
            join sc in db.SubCategory on t.SubCategoryId equals sc.Id
            join c in db.Category on sc.CategoryId equals c.Id
            group r by new { c.Id, c.CategoryName, SubCategoryId = sc.Id, sc.SubCategoryName } into gr
            select new
            {
                CategoryId = gr.Key.Id,
                CategoryName = gr.Key.CategoryName,
                SubCategoryId = gr.Key.SubCategoryId,
                SubCategoryName = gr.Key.SubCategoryName,
                Average = gr.Average(x => x.Marks)
            };
    
        // ToList() method executes the query, so we get the result on that line of code
        var result = query.ToList();
    }
