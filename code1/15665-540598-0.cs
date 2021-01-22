    Public Module ClassBreak
        Public Sub BreakOnAnyMember()
            Dim debugger As EnvDTE.Debugger = DTE.Debugger
            Dim sel As EnvDTE.TextSelection = DTE.ActiveDocument.Selection
            Dim editPoint As EnvDTE.EditPoint = sel.ActivePoint.CreateEditPoint()
            Dim classElem As EnvDTE.CodeElement = editPoint.CodeElement(vsCMElement.vsCMElementClass)
    
            If Not classElem Is Nothing Then
                For Each member As EnvDTE.CodeElement In classElem.Children
                    If member.Kind = vsCMElement.vsCMElementFunction Then
                        debugger.Breakpoints.Add("", DTE.ActiveDocument.FullName, member.StartPoint.Line)
                    End If
                Next
            End If
        End Sub
    
    End Module
