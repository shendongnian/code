    var dict = new Dictionary<int, NewForms>();
    
    while(reader.HasRows)
    {
        var id = int.Parse(reader["Id"].ToString())
    
        if(!dict.ContainsKey(id))
        {
            var newForm = new NewForms()
            {
                // Map properties from reader
            }
    
            dict[newForm.Id] = newForm; 
        }
    
        // Create Field from the reader's columns 
        var field = new Field()
        {
            // Map properties from reader
        };
    
        dict[id].Field.Add(field);
    }
   
    var newForms = dict.Values.ToList();
