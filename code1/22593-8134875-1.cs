    Dim dt As New DataTable
    dt.Columns.Add("A", GetType(Integer))
    dt.Columns.Add("B", GetType(Integer))
    dt.Columns.Add("C", GetType(Integer))
    dt.Rows.Add(New Object() {12, 13, DBNull.Value})
    
    Dim boolResult As Boolean = dt.Select("A>B-2").Length > 0
    
    dt.Columns.Add("result", GetType(Integer), "A+B*2+ISNULL(C,0)")
    Dim valResult As Object = dt.Rows(0)("result")
