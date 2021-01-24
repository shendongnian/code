    Root root = JsonConvert.DeserializeObject<Root>(json);
    foreach (var item in root.FirstTeamArrange.PlayerPos) //foreach (var item in root.SecondTeamArrange.PlayerPos)
    {
        if (item.Type == JTokenType.Integer)
            Console.WriteLine(item.Value<int>());
        else
            if (item.Type == JTokenType.Array)
            {
                var arr = item.ToObject<string[]>();
                foreach (var innerItem in arr)
                    Console.WriteLine(innerItem);
            }
    }
    Console.ReadLine();
    
