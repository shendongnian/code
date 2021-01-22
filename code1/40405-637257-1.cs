    Public Sub TestForEach
        Dim items As List(Of String) = New List(Of String)()
        items.Add("one")
        items.Add("two")
        items.Add("three")
        For Each item As string In items
            Debug.WriteLine(item)
        Next
    End Sub
