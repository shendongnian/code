    ''' <summary>
    ''' Returns a <see cref="Boolean"/> value indicating wether a selection is a <see cref="Excel.Range"/> Object.
    ''' </summary>
    ''' <param name="Selection">If not provided, ThisAddIn.Application.Selection is used by default.</param>
    ''' <returns></returns>
    Private Function IsRange(ByVal Optional Selection As Object = Nothing) As Boolean
        If Selection Is Nothing Then Selection = Globals.ThisAddIn.Application.Selection
        Try
            Dim MyRange As Excel.Range = Selection
        Catch ex As system.InvalidCastException
            Return False
        End Try
        Return True
    End Function
