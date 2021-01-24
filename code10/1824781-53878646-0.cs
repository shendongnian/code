    IQueryable<NewStruct> list = context.Table1
        .GroupJoin(context.Table2,
            e => new { id1 = e.Id1, id2 = e.Id2, dt = e.Datefield },
            q => new { id1 = q.Id1, id2 = q.Id2, dt = e.Datefield },
        (t1, t2) => new NewStruct { newId= t1.Id1, newTable2 = t2 });
