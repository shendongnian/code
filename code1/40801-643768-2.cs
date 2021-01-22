    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports System.Diagnostics
    Imports System.Text.RegularExpressions
    
    Public Module Helpers
        Sub SwapAssignment()
            If (Not IsNothing(DTE.ActiveDocument)) Then
                Dim text As String = CType(DTE.ActiveDocument.Selection, TextSelection).Text
                CType(DTE.ActiveDocument.Selection, TextSelection).Text _
                    = Regex.Replace(text, "([^\s]*)\s*=\s*([^\s]*);", "$2 = $1;")
            End If
        End Sub
    End Module
