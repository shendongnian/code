Class enumTest
    Function GetEnumeratorInFirstStyle() As IEnumerator(Of Integer)
        Return Enumerable.Empty(Of Integer)() ' Real code would do something better
    End Function
    Private Structure FirstStyleEnumerable
        Implements IEnumerable(Of Integer)
        Private myEnumTest As enumTest
        Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Integer) Implements System.Collections.Generic.IEnumerable(Of Integer).GetEnumerator
            Return myEnumTest.GetEnumeratorInFirstStyle
        End Function
        Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return myEnumTest.GetEnumeratorInFirstStyle
        End Function
        Sub New(ByVal newEnumTest As enumTest)
            myEnumTest = newEnumTest
        End Sub
    End Structure
    Public ReadOnly Property AsFirstStyleEnumerable As IEnumerable(Of Integer)
        Get
            Return New FirstStyleEnumerable(Me)
        End Get
    End Property
End Class
