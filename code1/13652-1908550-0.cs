    Public Class ListItemComparer
        Implements IComparer(Of ListItem)
        Public Function Compare(ByVal x As ListItem, ByVal y As ListItem) As Integer _
            Implements IComparer(Of ListItem).Compare
            Dim c As New CaseInsensitiveComparer
            Return c.Compare(x.Text, y.Text)
        End Function
    End Class
