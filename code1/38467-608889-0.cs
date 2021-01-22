    Sub BookmarksInTables()
        Dim aTable As Table
        Dim aBookmark As Bookmark
        
        For Each aBookmark In ActiveDocument.Bookmarks
            For Each aTable In ActiveDocument.Tables
                'If start of book mark is inside the table range or
                ' the end of a book mark is inside the table range then YES!
                If (aBookmark.Range.Start >= aTable.Range.Start _
                    And aBookmark.Range.Start <= aTable.Range.End) _
                Or (aBookmark.Range.End >= aTable.Range.Start _
                    And aBookmark.Range.End <= aTable.Range.End) Then
                    MsgBox aBookmark.Name + " is inside a table"
                Else
                    MsgBox aBookmark.Name + " is not inside a table"
                End If
            Next
        Next
    End Sub
