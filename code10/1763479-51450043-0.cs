    var output =
        from r in results.AsEnumerable()
        join c in csvData.AsEnumerable()
            on r.MemberId equals c.Field<string>("MEMBER ID")
        select new
        {
            c.Field1FromcsvData,
            c.Field2FromcsvData,
            r.Reason
        };
