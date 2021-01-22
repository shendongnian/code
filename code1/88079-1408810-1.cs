    Sub SwapAssignments()
        DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
        DTE.Find.FindWhat = "^{:b*}{([^=]+)} += +{([^=]+)};"
        DTE.Find.ReplaceWith = "\1\3 = \2;"
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocumentFunction
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = True
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
        DTE.Windows.Item("{CF2DDC32-8CAD-11D2-9302-005345000000}").Close()
    End Sub
