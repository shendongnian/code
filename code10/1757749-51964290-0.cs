    string ColumnName;
    var columnYouWant = "the column you want";
    var model = new AttributeMappingSource().GetModel(typeof(DataClassesDataContext));
    var table = model.GetTables().FirstOrDefault(table => table.TableName == "dbo.Sheet");
    if(table != null)
        ColumnName = table.RowType.DataMembers
        .First(member => member.MappedName == columnYouWant);
