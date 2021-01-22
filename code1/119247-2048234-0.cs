    Sub RegexReplace()
        Dim regex As String = InputBox("Enter regex for text to find")
        Dim replace As String = InputBox("Enter replacement pattern")
        Dim selection As EnvDTE.TextSelection = DTE.ActiveDocument.Selection
        Dim editPoint As EnvDTE.EditPoint
        selection.StartOfDocument()
        selection.EndOfDocument(True)
        DTE.UndoContext.Open("Custom regex replace")
        Try
            Dim content As String = selection.Text
            Dim result = System.Text.RegularExpressions.Regex.Replace(content, regex, replace)
            selection.Delete()
            selection.Collapse()
            Dim ed As EditPoint = selection.TopPoint.CreateEditPoint()
            ed.Insert(result)
        Catch ex As Exception
        Finally
            DTE.UndoContext.Close()
            DTE.StatusBar.Text = "Regex Find/Replace complete"
        End Try
    End Sub
