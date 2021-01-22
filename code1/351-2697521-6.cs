    Dim MyDictionary As SortedDictionary(Of String, MyDictionaryEntry)
    MyDictionaryListView.ItemsSource = MyDictionary.Values.OrderByDescending(Function(entry) entry.MyValue)
    Public Class MyDictionaryEntry ' Need Property for GridViewColumn DisplayMemberBinding
        Public Property MyString As String
        Public Property MyValue As Integer
    End Class
