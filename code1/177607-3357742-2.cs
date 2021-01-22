    object ParseUserInput(string jsonInput)
    {
      Type type = <get type instance somehow>
      var json = typeof(JsonConvert);
      var generic = json.GetMethods().Where(m => 
           m.Name == "DeserializeObject" &&
           m.GetParemeters().Count == 1).Single();
      var method = generic.MakeGenericMethod(type);
  
      return method.Invoke(null, jsonInput);
    }
