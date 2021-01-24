    var columnYouWant = "the column you want";
    string ColumnName = new AttributeMappingSource()
        .GetModel(typeof(DataClassesDataContext))
        .GetTables()
        .First(table => table.TableName == "dbo.Sheet")
            .RowType.DataMembers
                .First(member => member.MappedName == columnYouWant);
