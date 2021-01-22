    Option Strict Off
    Option Explicit Off
    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports System.Diagnostics
    Imports System.Windows.Forms
    
    Public Module Breakpoints
    
        Sub AddBreakpointsToAllFunctionsAndProperties()
            Try
                If DTE.ActiveSolutionProjects.Length <> 1 Then
                    MsgBox("Select one project within the Solution Explorer, then re-run this macro.")
                    Exit Sub
                End If
    
                AddBreakpointsToProject(DTE.ActiveSolutionProjects(0))
            Catch ex As System.Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
    
        Private Sub AddBreakpointsToProject(ByVal proj As Project)
            For i As Integer = 1 To proj.ProjectItems.Count
                If Not proj.ProjectItems.Item(i).FileCodeModel Is Nothing Then
                    AddBreakpointsToProjectItems(proj.ProjectItems.Item(i).FileCodeModel.CodeElements)
                End If
            Next
        End Sub
    
    
        Private Sub AddBreakpointsToProjectItems(ByVal colCodeElements As CodeElements)
            Dim objCodeElement As EnvDTE.CodeElement
    
            If Not (colCodeElements Is Nothing) Then
                For Each objCodeElement In colCodeElements
                    AddBreakpointsToProjectItem(objCodeElement)
                Next
            End If
        End Sub
    
        Private Sub AddBreakpointsToProjectItem(ByVal objCodeElement As CodeElement)
    
            Dim objCodeNamespace As EnvDTE.CodeNamespace
            Dim objCodeType As EnvDTE.CodeType
            Dim objCodeFunction As EnvDTE.CodeFunction
            Dim objCodeProperty As EnvDTE.CodeProperty
    
            Try
                'MessageBox.Show(objCodeElement.FullName & " (Kind: " & objCodeElement.Kind.ToString & ")")
    
                If objCodeElement.Kind = vsCMElement.vsCMElementFunction Then
                    objCodeFunction = DirectCast(objCodeElement, EnvDTE.CodeFunction)
                    If objCodeFunction.Access = vsCMAccess.vsCMAccessPublic Then
                        DTE.Debugger.Breakpoints.Add(objCodeElement.FullName)
                    End If
                ElseIf objCodeElement.Kind = vsCMElement.vsCMElementProperty Then
                    objCodeProperty = DirectCast(objCodeElement, EnvDTE.CodeProperty)
                    DTE.Debugger.Breakpoints.Add(objCodeElement.FullName)
                End If
            Catch ex As System.Exception
                ' Ignore
            End Try
    
            If TypeOf objCodeElement Is EnvDTE.CodeNamespace Then
                objCodeNamespace = CType(objCodeElement, EnvDTE.CodeNamespace)
                AddBreakpointsToProjectItems(objCodeNamespace.Members)
            ElseIf TypeOf objCodeElement Is EnvDTE.CodeType Then
                objCodeType = CType(objCodeElement, EnvDTE.CodeType)
                AddBreakpointsToProjectItems(objCodeType.Members)
            ElseIf TypeOf objCodeElement Is EnvDTE.CodeFunction Then
                objCodeFunction = DirectCast(objCodeElement, EnvDTE.CodeFunction)
                AddBreakpointsToProjectItems(CType(objCodeElement, CodeFunction).Parameters)
            End If
        End Sub
    
    End Module
