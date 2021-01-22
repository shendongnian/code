    Sub BlockComment()
        Dim selection As EnvDTE.TextSelection
        Dim startPoint As EnvDTE.EditPoint
        Dim endPoint As TextPoint
        Dim commentStart As String
    
        selection = DTE.ActiveDocument.Selection()
        startPoint = selection.TopPoint.CreateEditPoint()
        endPoint = selection.BottomPoint.CreateEditPoint()
        DTE.UndoContext.Open("Block Comment")
        startPoint.Insert("/*")
        endPoint.Insert("*/")
        DTE.UndoContext.Close()
    End Sub
