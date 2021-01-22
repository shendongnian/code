    Protected Overrides Sub RaisePostBackEvent(ByVal eventArgument As String)
                If eventArgument.StartsWith("rc") Then
                    Dim index As Integer = Int32.Parse(eventArgument.Substring(2))
                    Dim args As New GridViewRowClickedEventArgs(Me.Rows(index))
                    OnRowClicked(args)
                Else
                    MyBase.RaisePostBackEvent(eventArgument)
                End If
    
            End Sub
     Public Class GridViewRowClickedEventArgs
            Inherits EventArgs
    
            Private _row As GridViewRow
            Public Sub New(ByVal row As GridViewRow)
                _row = row
            End Sub
            Public ReadOnly Property Row() As GridViewRow
                Get
                    Return _row
                End Get
            End Property
        End Class
