     JSchemaGenerator generator = new JSchemaGenerator();
     JSchema schema = generator.Generate(typeof(WallMartData));
    
     string json = @"...";
     JObject wallMartData = JObject.Parse(json);
     if(wallMartData.IsValid(schema))
     {
            //if json matching the schema aka the class account
     }
     else
     {
         //the json is invalid
     }
