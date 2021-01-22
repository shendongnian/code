    Public Default ReadOnly Property Item(ByVal index As Integer) As CustomerRow
        Get
            Return CType(Me.Rows(index), CustomerRow)
        End Get
    End Property
