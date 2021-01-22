    Private Sub PopulateTreeView(tv As TreeView, paths As List(Of String), pathSeparator As Char)
        Dim lastnode As TreeNode = Nothing
        Dim subPathAgg As String
        For Each path In paths
            subPathAgg = String.Empty
            lastnode = Nothing
            For Each subPath In path.Split(pathSeparator)
                subPathAgg += subPath + pathSeparator
                Dim nodes() As TreeNode = tv.Nodes.Find(subPathAgg, True)
                If nodes.Length = 0 Then
                    If IsNothing(lastnode) Then
                        lastnode = tv.Nodes.Add(subPathAgg, subPath)
                    Else
                        lastnode = lastnode.Nodes.Add(subPathAgg, subPath)
                    End If
                Else
                    lastnode = nodes(0)
                End If
            Next
        Next
    End Sub
