    <Extension()> _
    Public Function OrderBy(Of T)(ByVal query As IEnumerable(Of T), ByVal sortColumn As String, ByVal direction As String) As IEnumerable(Of T)
            Dim methodName As String = String.Format("OrderBy{0}", If(direction.ToLower() = "asc", "", "Descending"))
            Dim parameter As ParameterExpression = Expression.Parameter(GetType(T), "p")
            Dim memberAccess As MemberExpression = Nothing
    
            For Each _property As Object In sortColumn.Split(".")
                memberAccess = MemberExpression.Property(If(memberAccess, CType(parameter, Expression)), _property)
            Next
    
            Dim orderByLambda As LambdaExpression = Expression.Lambda(memberAccess, parameter)
            '
            Dim myEnumeratedObject As ParameterExpression = Expression.Parameter(GetType(IEnumerable(Of T)), "MyEnumeratedObject")
    
            Dim result As MethodCallExpression = Expression.Call(GetType(Enumerable), _
                      methodName, _
                      New System.Type() {GetType(T), memberAccess.Type}, _
                      myEnumeratedObject, _
                      orderByLambda)
    
            Dim lambda = Expression.Lambda(Of Func(Of IEnumerable(Of T), IEnumerable(Of T)))(result, myEnumeratedObject)
            Return lambda.Compile()(query)
        End Function
