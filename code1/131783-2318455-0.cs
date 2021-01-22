        If entities Is Nothing Then entities = New CompanyEntities()
        Dim contacts As ObjectQuery(Of Contact) = compiledQuery.Invoke(entities)
        If NoTracking Then contacts.MergeOption = MergeOption.NoTracking
        Return contacts.ToList()
    End Function
