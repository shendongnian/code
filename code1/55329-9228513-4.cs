    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports System.Diagnostics
    
    Public Module MacroMod01
        Sub ExpandAllRegions()
    	' comment out all #region occurances
            DTE.ExecuteCommand("Edit.Replace")
            DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
            DTE.Find.FindWhat = "#region"
            DTE.Find.ReplaceWith = "'#region"
            DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocument
            DTE.Find.MatchCase = False
            DTE.Find.MatchWholeWord = False
            DTE.Find.MatchInHiddenText = True
            DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxLiteral
            DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
            DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
            DTE.Find.Execute()
    
    	' uncomment all #region occurances
            DTE.ExecuteCommand("Edit.Replace")
            DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
            DTE.Find.FindWhat = "'#region"
            DTE.Find.ReplaceWith = "#region"
            DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocument
            DTE.Find.MatchCase = False
            DTE.Find.MatchWholeWord = False
            DTE.Find.MatchInHiddenText = True
            DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxLiteral
            DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
            DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
            DTE.Find.Execute()
    
    	'close the find 'n replace dialog
            DTE.Windows.Item("{CF2DDC32-8CAD-11D2-9302-005345000000}").Close()  
    
        End Sub
    
    End Module
