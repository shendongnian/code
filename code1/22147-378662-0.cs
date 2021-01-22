    Public Property NotValue() As Boolean
        Get
            Return Not BO.Value
        End Get
        Set(ByVal value As Boolean)
            BO.Value = Not value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NotValue"))
        End Set
    End Property
    Private Sub BO_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles BO.PropertyChanged
        If e.PropertyName = "Value" Then
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NotValue"))
        End If
    End Sub
