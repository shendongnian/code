        List<Dictionary<string, string>> People= new List<Dictionary<string, string>>();
		
		People.Add(new Dictionary<string, string>());
        People[0].Add("ID Number", "1");
        People[0].Add("Name", "John");
		for (int i = 0; i < People.Count; i++)
        {
            Console.WriteLine(People[i]["ID Number"]);
            Console.WriteLine(People[i]["Name"]);
        }
