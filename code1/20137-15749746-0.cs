     Sub InsertCurlyBraces()
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "{"
        DTE.ActiveDocument.Selection.NewLine(2)
        DTE.ActiveDocument.Selection.Text = "}"
        DTE.ActiveDocument.Selection.LineUp()
    End Sub
