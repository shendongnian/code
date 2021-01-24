    List<Tbl1> tbl1data;
    List<Tbl2> tbl2data;
    List<Tbl3> tbl3data;
    using (var tbl1Context = new AmsdbaContext(options))
    using (var tbl2Context = new AmsdbaContext(options))
    using (var tbl3Context = new AmsdbaContext(options))
    {
        var tbl1task = tbl1Context.Tbl1.ToListAsync();
        var tbl2task = tbl2Context.Tbl2.ToListAsync();
        var tbl3task = tbl3Context.Tbl3.ToListAsync();
        tbl1data = await tbl1task;
        tbl2data = await tbl2task;
        tbl3data = await tbl3task;
    }
