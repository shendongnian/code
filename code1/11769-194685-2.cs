    Public Class Item
       Public ID As Guid
       Public Text As String
       Public Sub New(ByVal id As Guid, ByVal name As String)
          Me.ID = id
          Me.Text = name
       End Sub
    End Class
    Public Sub Load(sender As Object, e As EventArgs) Handles Me.Load
       Dim box As New ComboBox
       Me.Controls.Add(box)          'Sorry I forgot this line the first time.'
       Dim h As IntPtr = box.Handle  'Im not sure you need this but you might.'
       Try
          box.Items.Add(New Item(Guid.Empty, Nothing))
       Catch ex As Exception
          MsgBox(ex.ToString())
       End Try
    End Sub
