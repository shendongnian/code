    Sub SetAllCompile()
            Dim scs As EnvDTE.SolutionContexts = DTE.Solution.SolutionBuild.ActiveConfiguration.SolutionContexts
            Dim sc As EnvDTE.SolutionContext
            For Each sc In scs
                sc.ShouldBuild = True
            Next
        End Sub
    Sub SetNoneCompile()
        Dim scs As EnvDTE.SolutionContexts = DTE.Solution.SolutionBuild.ActiveConfiguration.SolutionContexts
        Dim sc As EnvDTE.SolutionContext
        For Each sc In scs
            sc.ShouldBuild = False
        Next
    End Sub
    Sub SetInvertCompile()
        Dim scs As EnvDTE.SolutionContexts = DTE.Solution.SolutionBuild.ActiveConfiguration.SolutionContexts
        Dim sc As EnvDTE.SolutionContext
        For Each sc In scs
            sc.ShouldBuild = Not sc.ShouldBuild
        Next
    End Sub
    Sub SetSelectedCompile()
        Dim scs As EnvDTE.SolutionContexts = DTE.Solution.SolutionBuild.ActiveConfiguration.SolutionContexts
        Dim sc As EnvDTE.SolutionContext
        For Each sc In scs
            sc.ShouldBuild = False
        Next
        Dim selItem As SelectedItem
        For Each selItem In DTE.SelectedItems
            For Each sc In scs
                Try
                    If (sc.ProjectName = selItem.Project.UniqueName) Then
                        sc.ShouldBuild = True
                    End If
                Catch
                End Try
            Next
        Next
    End Sub
