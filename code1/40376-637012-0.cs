        Protected Overrides Sub LoadViewState( _
            ByVal savedState As Object)
            Dim p As Pair = TryCast(savedState, Pair)
            If p IsNot Nothing Then
                MyBase.LoadViewState(p.First)
                CType(Author, IStateManager).LoadViewState(p.Second)
                Return
            End If
            MyBase.LoadViewState(savedState)
        End Sub
