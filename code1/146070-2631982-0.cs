    Dim dt As DataTable = ...
    Dim idColumn As DataColumn = table.Columns("ID")
    Dim nameColumn As DataColumn = table.Columns("Name")
    Dim descriptionColumn As DataColumn = table.Columns("Description")
    For Each r As DataRow In dt.Rows
        ' NB: lookup through a DataColumn object, not through a name, nor an index: '
        Dim id = r(idColumn)
        Dim name = r(idColumn)
        Dim description = r(idColumn)
        ...
    Next
