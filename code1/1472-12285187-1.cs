    Sub IfStatement()
        DTE.ActiveDocument.Selection.Text = "if ()"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "{"
        DTE.ActiveDocument.Selection.NewLine(2)
        DTE.ActiveDocument.Selection.Text = "}"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "else"
        DTE.ActiveDocument.Selection.NewLine(2)
        DTE.ActiveDocument.Selection.Text = "{"
        DTE.ActiveDocument.Selection.NewLine(2)
        DTE.ActiveDocument.Selection.Text = "}"
        DTE.ActiveDocument.Selection.LineUp(False, 7)
        DTE.ActiveDocument.Selection.EndOfLine()
        DTE.ActiveDocument.Selection.CharLeft(3)
    End Sub
