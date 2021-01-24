    while (reader.Read())
    {
    	object[] values = new object[3];
    	reader.GetValues(values);
    
    	MyModelClass model = new MyModelClass();
    
    	model.ID = values[0].ToString();
    	model.ValueProperty = values[1].ToString();
    	model.ValueProperty2 = values[2].ToString();
    
    	result.Add(model.ID, model);
    }
