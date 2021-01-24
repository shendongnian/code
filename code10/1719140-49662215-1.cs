    // load textfile and convert lines into objects
    //  var inFile = File.ReadLines(...);
    var inData = inFile.Select(line => line.Split('\t'))
                       .Select(lineArray => new {
                           TableName = lineArray[0],
                           PrimaryKey = lineArray[1],
                           ColName = lineArray[2],
                           ColValue = lineArray[3],
                       });
    // Buld a dictionary of tables and their columns
    var tableColNames = inData.Select(r => new { r.TableName, r.ColName })
                              .Distinct()
                              .GroupBy(r => r.TableName, r => r.ColName)
                              .ToDictionary(rg => rg.Key, rg => rg.Select(r => r).ToList());
    var tableNames = tableColNames.Keys.ToList();
    // build all of the tables into a dictionary of tables
    var dataTables = new Dictionary<string, DataTable>();
    foreach (var tableName in tableNames) {
        var aTable = new DataTable(tableName);
        var primaryKeyCol = new DataColumn("PrimaryKey");
        aTable.Columns.Add(primaryKeyCol);
        aTable.PrimaryKey = new[] { primaryKeyCol };
        foreach (var colName in tableColNames[tableName]) {
            aTable.Columns.Add(new DataColumn(colName));
        }
        dataTables[tableName] = aTable;
    }
    // load all of the tables with their data
    foreach (var aTable in dataTables.Values) {
        var inRows = inData.Where(r => r.TableName == aTable.TableName)
                           .GroupBy(r => r.PrimaryKey);
        foreach (var row in inRows) {
            var newRow = aTable.NewRow();
            newRow["PrimaryKey"] = row.Key;
            foreach (var col in row)
                newRow[col.ColName] = col.ColValue;
            aTable.Rows.Add(newRow);
        }
    }
    // build the combined table with all columns
    var combinedTable = new DataTable();
    foreach (var aTable in dataTables.Values)
        combinedTable.Columns.AddRange(aTable.DataColumns()
                                             .Where(dc => !combinedTable.ColumnNames()
                                                                        .Contains(dc.ColumnName))
                                             .Select(dc => new DataColumn(dc.ColumnName))
                                             .ToArray());
    // find and index the common columns between tables
    var commonColNames = new Dictionary<string, Dictionary<string, string>>(); // [TableName]=>[LinkedTableName]=>ColumnName
    var indexes = new Dictionary<string, Dictionary<string, DataRow>>(); // [TableName]=>[ColumnValue]=>DataRow
    for (int j1 = 0; j1 < tableNames.Count; ++j1) { // foreach table, find its linked tables
        var startTableName = tableNames[j1];
        var startTable = dataTables[startTableName];
        var startTableColNames = startTable.NonPrimaryKeyColumnNames().ToList();
        var linkedTables = tableNames.Skip(j1 + 1) // only find links to later tables
                                         .Select(n => (TableName: n, CommonColName: startTableColNames.Intersect(dataTables[n].ColumnNames()).SingleOrDefault()))
                                         .Where(tc => tc.CommonColName != null);
        if (linkedTables.Count() > 0) { // if it has linked tables, save the linking column and index that column
            var linkingColNames = new Dictionary<string, string>(); // [LinkedTableName]=>ColumnName
            foreach (var linkedTable in linkedTables) {
                linkingColNames.Add(linkedTable.TableName, linkedTable.CommonColName);
                if (!indexes.ContainsKey(linkedTable.TableName)) { // only build indexes once per linking column
                    var colIndex = dataTables[linkedTable.TableName].AsEnumerable()
                                                                      .Select(r => (Key: r.Field<string>(linkedTable.CommonColName), DataRow: r))
                                                                      .ToDictionary(t => t.Key, t => t.DataRow);
                    indexes.Add(linkedTable.TableName, colIndex);
                }
            }
            commonColNames[startTableName] = linkingColNames;
        }
    }
    // combine the tables starting with the first table
    var firstTableName = tableNames[0];
    var firstTable = dataTables[firstTableName];
    var firstTableColNames = firstTable.ColumnNames().ToList();
    // foreach DataRow in the first table
    foreach (var r1 in firstTable.AsEnumerable()) {
        var newRow = combinedTable.NewRow();
        // load the first table DataRow into the combined DataRow
        newRow.CopyColumnValues(r1, firstTableColNames);
        // find all the linked tables and merge their DataRows into the combined DataRow
        var linkedTableNamesStack = new Stack<(string TableName, string LinkedTableName)>();
        linkedTableNamesStack.PushRange(commonColNames[firstTableName].Keys.Select(ltn => (firstTableName,ltn)));
        while (linkedTableNamesStack.Count > 0) {
            var nextTableLink = linkedTableNamesStack.Pop();
            if (commonColNames.TryGetValue(nextTableLink.LinkedTableName, out var linkedTables))
                linkedTableNamesStack.PushRange(linkedTables.Keys.Select(ltn => (nextTableLink.LinkedTableName,ltn)));
            var linkingColName = commonColNames[nextTableLink.TableName][nextTableLink.LinkedTableName];
            var linkingColValue = newRow.Field<string>(linkingColName);
            var linkedRow = indexes[nextTableLink.LinkedTableName][linkingColValue];
            newRow.CopyColumnValues(linkedRow, linkedRow.Table.NonPrimaryKeyColumnNames());
        }
        combinedTable.Rows.Add(newRow);
    }
