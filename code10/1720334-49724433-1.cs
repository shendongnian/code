    var returns = (
        // Grab from returns table
        from r in ctx.Returns
        // Inner join with return items
        join ri in ctx.ReturnItems on r.ReturnID equals ri.ReturnID
        // Filter down by return 'closed on' date
        where (
            r.ClosedOn > startDate &&
            r.ClosedOn <= endDate
        )
        // Join with return item tests.  The 'into' clause is powerful and should be used regularly for complex queries;
        // really, the lack of an 'into' projection clause can usually be thought of as shorthand.  Here, 'into' projects
        // the 0..n join hierarchically as an IEnumerable in what is called a 'group join'.
        join rit in ctx.ReturnItemTests on ri.ReturnItemID equals rit.ReturnItemID into ritGroupJoined
        // 'Flatten out' the join result with the 'from' clause, meaning that group join results with eg. 3 matches will
        // cause 3 items in the resultant enumeration, and group join results with zero matches will cause zero items
        // in the resultant enumeration.  The .DefaultIfEmpty() method means that these results will instead cause one
        // item in the resultant enumeration, having the default value for that type (ie. null, as it's a reference type).
        // Note that without the 'into' group join above, it's not possible to access the join results with zero matches as
        // they are automatically discarded from the results during the default 'inner join'-style flattening.
        from rit in ritGroupJoined.DefaultIfEmpty()
        // Project these results into an intermediary object to allow ReturnItemTestStatus to be null (as a int? type);
        // without this, we couldn't group them because any grouped items whose ReturnItemTestStatus was null would cause
        // a type error, null being an invalid value for the ReturnItemTests.ReturnItemTestStatus property (an int type).
        select new {
            ReturnItemStatus = ri.ReturnItemStatus,
            ReturnItemTestStatus = rit == null ? null : (TestStatusEnum?)rit.ReturnItemTestStatus,
        } into retData
        // Finally, we can now group this flattened data by both item status and item test status; to group by multiple
        // fields in LINQ, use an anonymous type containing the fields to group by.
        group retData by new { retData.ReturnItemStatus, retData.ReturnItemTestStatus } into retGrouped
        // ... and project into an object to get our item status counts.
        select new
        {
            ReturnItemStatus = retGrouped.Key.ReturnItemStatus,
            ReturnItemTestStatus = retGrouped.Key.ReturnItemTestStatus,
            Count = retGrouped.Count()
        }
    ).ToList();
