    Public Shared Sub SortDropDown(ByVal cbo As DropDownList)
        Dim lstListItems As New List(Of ListItem)
        For Each li As ListItem In cbo.Items
            lstListItems.Add(li)
        Next
        lstListItems.Sort(New ListItemComparer)
        cbo.Items.Clear()
        cbo.Items.AddRange(lstListItems.ToArray)
    End Sub
