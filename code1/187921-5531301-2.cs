Interface IQualifiedEnumerable(Of T, U)
    Function GetEnumerator() As IEnumerable(Of U)
End Interface
Structure QualifiedEnumerableWrapper(Of T, U)
    Implements IEnumerable(Of U)
    Private myEnumerable As IQualifiedEnumerable(Of T, U)
    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of U) Implements System.Collections.Generic.IEnumerable(Of U).GetEnumerator
        Return myEnumerable.GetEnumerator
    End Function
    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return myEnumerable.GetEnumerator
    End Function
    Sub New(ByVal newEnumerable As IQualifiedEnumerable(Of T, U))
        myEnumerable = newEnumerable
    End Sub
End Structure
Class EnumTest2
    Implements IQualifiedEnumerable(Of FirstEnumerationStyle, Integer)
    Implements IQualifiedEnumerable(Of SecondEnumerationStyle, Integer)
    Private Class FirstEnumerationStyle     ' Marker classes for generics
    End Class
    Private Class SecondEnumerationStyle
    End Class
    Private Function GetFirstStyleEnumerator() As System.Collections.Generic.IEnumerable(Of Integer) Implements IQualifiedEnumerable(Of FirstEnumerationStyle, Integer).GetEnumerator
        Return Enumerable.Empty(Of Integer)()
    End Function
    Private Function GetSecondStyleEnumerator() As System.Collections.Generic.IEnumerable(Of Integer) Implements IQualifiedEnumerable(Of SecondEnumerationStyle, Integer).GetEnumerator
        Return Enumerable.Empty(Of Integer)()
    End Function
    Public ReadOnly Property AsFirstStyleEnumerable As IEnumerable(Of Integer)
        Get
            Return New QualifiedEnumerableWrapper(Of FirstEnumerationStyle, Integer)
        End Get
    End Property
    Public ReadOnly Property AsSecondStyleEnumerable As IEnumerable(Of Integer)
        Get
            Return New QualifiedEnumerableWrapper(Of SecondEnumerationStyle, Integer)
        End Get
    End Property
End Class
