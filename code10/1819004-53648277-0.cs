    var fk1 = oldDatasetInMemory.Columns["ForeignKeyColumn1"];
    // ...
    var alreadyMigratedTable1 = newModelContext.alreadyMigratedTable1.ToDictionary(
        x => x.uniquePropertyOnNewDataset);
    // ...
    if (alreadyMigratedTable1.TryGetValue(masterData.uniquePropertyOnOldDataset, out var val))
        row[fk1] = val;
