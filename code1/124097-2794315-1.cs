    Public Shared Sub DatasetAutoMerge(ByVal Source As Data.DataSet, ByVal Target As Data.DataSet)
        Target.EnforceConstraints = False
        For Each dtTarget As Data.DataTable In Target.Tables
            For Each dtSource As Data.DataTable In Source.Tables
                Dim dtMatch = dtSource
                For Each dcTarget As Data.DataColumn In dtTarget.Columns
                    If Not dtSource.Columns.Contains(dcTarget.ColumnName) Then
                        'The source does not have a column we need by name, not a match'
                        dtMatch = Nothing
                        Exit For
                    End If
                Next
                If dtMatch IsNot Nothing Then
                    dtTarget.Merge(dtMatch, False, Data.MissingSchemaAction.Ignore)
                    Exit For
                End If
            Next
        Next
        Target.EnforceConstraints = True
    End Sub
