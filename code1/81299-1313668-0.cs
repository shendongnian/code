    <Extension()> _
    Public Module TypeAsExtensions
        <Extension()> _
        Public Function SelectAs(Of TElement, TOriginalType, TTargetType)( _
            ByVal source As IQueryable(Of TElement), _
            ByVal selector As Expression(Of Func(Of TElement, TOriginalType))) _
            As IQueryable(Of TTargetType)
    
            Return Queryable.Select(source, _
                Expression.Lambda(Of Func(Of TElement, TTargetType))( _
                    Expression.TypeAs(selector.Body, GetType(TTargetType)), _
                    selector.Parameters(0)))
        End Function
    
        <Extension()> _
        Public Function SelectAsNullable(Of TElement, TType As Structure)( _
            ByVal source As IQueryable(Of TElement), _
            ByVal selector As Expression(Of Func(Of TElement, TType))) _
            As IQueryable(Of TType?)
            Return SelectAs(Of TElement, TType, TType?)(source, selector)
        End Function
    End Module
