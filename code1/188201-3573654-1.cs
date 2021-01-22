    List<MyModel> models = new List<MyModel>();
    foreach (DataRow row in dt.Rows)
    {
        MyModel model = new MyModel 
        {
            Id = (int)row[0],
            Prop1 = (string)row[1],
            Prop2 = (string)row[2]
        };
        models.Add(model);
    }
