    var b= new DataTable("B");
    DataColumn id= new DataColumn("Id", typeof(int));
    billablePriceMapId.AutoIncrement = true;
    billable.Columns.Add(id);
    DataColumn parentId= new DataColumn("ParentGuid", typeof(Guid));
    billable.Columns.Add(parentGuid);
    DataColumn[] keys = new DataColumn[1];
    keys[0] = id;
    billable.PrimaryKey = keys;
