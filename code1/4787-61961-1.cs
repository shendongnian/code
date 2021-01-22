        Dim itemValues As Array = System.Enum.GetValues(GetType(Response))
        Dim itemNames As Array = System.Enum.GetNames(GetType(Response))
        For i As Integer = 0 To itemNames.Length
            Dim item As New ListItem(itemNames(i), itemValues(i))
            dropdownlist.Items.Add(item)
        Next
