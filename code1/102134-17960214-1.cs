    Public Class TreeViewSelectedNodeChangeEventHandler
    Public Event SelectedTreeNodeChanged(sender As Object, e As EventArgs)
    Private m_selectedNode As TreeNode
    Private WithEvents m_tvw As TreeView
    Public Shared Function FromTree(tree As TreeView) As TreeViewSelectedNodeChangeEventHandler
        If Not IsNothing(tree) Then
            Return New TreeViewSelectedNodeChangeEventHandler(tree)
        End If
        Return Nothing
    End Function
    ''' <summary>Assigns 'Value' to 'this' and returns 'Value'.</summary>
    Private Function InLineAssign(Of V)(ByRef this As V, value As V) As V
        Dim ret = value
        this = value
        Return ret
    End Function
