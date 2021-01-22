    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports System.Diagnostics
    
    Public Module OrganiseUsings
    
        Public Sub RemoveAndSortAll()
            On Error Resume Next
            Dim sol As Solution = DTE.Solution
    
            For i As Integer = 1 To sol.Projects.Count    
                Dim proj As Project = sol.Projects.Item(i)    
                For j As Integer = 1 To proj.ProjectItems.Count    
                    RemoveAndSortSome(proj.ProjectItems.Item(j))    
                Next    
            Next    
        End Sub    
        
        Private Sub RemoveAndSortSome(ByVal projectItem As ProjectItem)
            On Error Resume Next
            If projectItem.Kind = Constants.vsProjectItemKindPhysicalFile Then    
                If projectItem.Name.LastIndexOf(".cs") = projectItem.Name.Length - 3 Then
                    Dim window As Window = projectItem.Open(Constants.vsViewKindCode)
    
                    window.Activate()
    
                    projectItem.Document.DTE.ExecuteCommand("Edit.RemoveAndSort")
    
                    window.Close(vsSaveChanges.vsSaveChangesYes)
                End If    
            End If    
    
            For i As Integer = 1 To projectItem.ProjectItems.Count    
                RemoveAndSortSome(projectItem.ProjectItems.Item(i))    
            Next
        End Sub   
    End Module
