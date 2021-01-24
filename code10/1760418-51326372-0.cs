        CloudTableClient tableClient = new CloudTableClient("YOUR CONNECTION STRING");
        var AllTables = tableClient.ListTables();          
        if(AllTables != null)
        {
            foreach (var table in AllTables)
            {
                // table.Name is your property
            } 
        }
