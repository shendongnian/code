    var models = new Dictionary<string, Model>();
    while (reader.Read())
    {
        var om = new Model();
        if (reader != null)
        {
            var name = reader.GetString(0);
            var file = reader.GetString(1);
            if (models.Contains(name))
                models[name].files.Add(file); 
            else
            {
                models.Add(name, new Model
                {
                    name = name,
                    files = new List<string>{files}
                });
            }
        }
    }
