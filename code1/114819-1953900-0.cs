    DTE.ExecuteCommand("Edit.Find")
    DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
    DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocument
    DTE.Find.FindWhat = "<get$"
    DTE.Find.MatchCase = False
    DTE.Find.MatchWholeWord = False
    DTE.Find.Backwards = False
    DTE.Find.MatchInHiddenText = True
    DTE.Find.Action = vsFindAction.vsFindActionFind
    While DTE.Find.Execute() <> vsFindResult.vsFindResultNotFound
        DTE.ActiveDocument.Selection.LineDown(True, 6)
        DTE.ExecuteCommand("Edit.Delete")
        DTE.ActiveDocument.Selection.Text = "get; set;"
    End While
