    var rowsOnlyInA = 
        from a in A.Tables[0].AsEnumerable()
        join b in B.Tables[0].AsEnumerable() 
        on     new{ ColA = a.Field<string>("ColA"), ColB = a.Field<string>("ColB") }
        equals new{ ColA = b.Field<string>("ColA"), ColB = b.Field<string>("ColB") } into ps
        from p in ps.DefaultIfEmpty()
        where p == null
        select a;
    
    if(rowsOnlyInA.Any())
    {
       DataTable resulTable = rowsOnlyInA.CopyToDataTable();
    }
