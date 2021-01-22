        Private Sub RemoveAndSortSome(ByVal projectItem As ProjectItem)
        On Error Resume Next
        If projectItem.Kind = Constants.vsProjectItemKindPhysicalFile Then
            If projectItem.Name.LastIndexOf(".cs") = projectItem.Name.Length - 3 Then
                Dim window As Window = projectItem.Open(Constants.vsViewKindCode)
                window.Activate()
                projectItem.Document.DTE.ExecuteCommand("Edit.RemoveAndSort")
                window.Close(vsSaveChanges.vsSaveChangesYes)
            ElseIf projectItem.Name.LastIndexOf(".vb") = projectItem.Name.Length - 3 Then
                Dim window As Window = projectItem.Open(Constants.vsViewKindCode)
                window.Activate()
                projectItem.Document.DTE.ExecuteCommand("EditorContextMenus.CodeWindow.OrganizeImports.RemoveandSortImports")
                window.Close(vsSaveChanges.vsSaveChangesYes)
            End If
        End I
