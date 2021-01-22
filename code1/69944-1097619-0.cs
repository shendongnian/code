        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim xc As ColorNum = TryCast(x, ColorNum)
            Dim yc As ColorNum = TryCast(y, ColorNum)
            If x.color = Red Then
                Return 1
            ElseIf y.color = Red Then
                Return -1
            Else
                Return 0
            End If
        End Function
    End Class
