    ''' <summary>
    ''' Returns the parent System.Windows.form of the control
    ''' </summary>
    ''' <param name="parent"></param>
    ''' <returns>First parent form or null if no parent found</returns>
    ''' <remarks></remarks>
    Public Shared Function GetParentForm(ByVal parent As Control) As Form
        Dim form As Form = TryCast(parent, Form)
        If form IsNot Nothing Then
            Return form
        End If
        If parent IsNot Nothing Then
            ' Walk up the control hierarchy
            Return GetParentForm(parent.Parent)
        End If
        ' Control is not on a Form
        Return Nothing
    End Function
