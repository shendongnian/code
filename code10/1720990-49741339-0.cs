    // meaningful names - i is kinda "defacto standard" as a for loop counter
    for (int i = 0; i < List.Count; i++)
    {
        // using j for nesting loops is also kinda "defacto standard"
        for(int j = 0; j < 60; j++)
        {
            // you already know it's a client, use var!
            var client = new Client();
            client.Name = List[record].Name;
            client.Date = currentDate.AddDays(j % 30);
            List2.Add(client);
        }
    }
