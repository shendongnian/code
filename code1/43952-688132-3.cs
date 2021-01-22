    <Extension()> _
       Function GetRelation(Of TEntity As Type)(ByVal entity As TEntity, ByVal ParamArray path() As TEntity) As String
            GetRelation = entity.Name
            For Each type In path
                GetRelation &= "." & type.Name
            Next
       End Function
    
    'Here is your line:
    Dim x = Context.Employee.Include(GetType(Contact).GetRelation(GetType(SalesOrderHeader
    
    ), GetType(SalesOrderDetail)))
    
