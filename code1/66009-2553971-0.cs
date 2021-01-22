    Private Shared AddT As Func(Of T, T, T)
    If AddT = Nothing Then
        Dim paramX As Expressions.ParameterExpression = Expressions.Expression.Parameter(GetType(T), "x")
        Dim paramY As Expressions.ParameterExpression = Expressions.Expression.Parameter(GetType(T), "y")
        Dim body As Expressions.BinaryExpression = Expressions.Expression.AddChecked(paramX, paramY)
        Matrix(Of T).AddT = Expressions.Expression.Lambda(Of Func(Of T, T, T))(body, paramX, paramY).Compile
    End If
    Private a as MyType
    Private b as MyType
    AddT(a,b) 'instead of a+b
