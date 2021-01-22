    // First i build two String[] based on my Hastable.Keys. 
    // One which holds the values, one which creates parameter names.
    
    Hashtable hashNames;
    String[] names = new String[hashName.Keys.Count];
    String[] nameTags = new String[hashName.Keys.Count];
    int c = 0;
                
    foreach (String k in hashName.Keys)
    {
         names[c] = k;
         nameTags[c] = "@tag" + c.ToString();
         c++;
    }
    
    // after this i create my statement using the nameTags String[]
    
    String statementValueTags = String.Join(",", nameTags);
    String query = String.Format("SELECT Name, FROM SomeTable WHERE (Name IN ({0}))", statementValueTags);
    
    // for adding the parameterized Statements i use a for loop 
    // where i add the values from my String[]
    SQLiteCommand command = new SQLiteCommand(query, _databaseConnection);
    for (int i = 0; i < names.Length; i++)
    {
         command.Parameters.AddWithValue(nameTags[i], names[i]);
    }
    SQLiteDataReader reader = command.ExecuteReader();
    
    while(reader.Read())
    {
         Console.WriteLine(reader[0]);
    }
            
