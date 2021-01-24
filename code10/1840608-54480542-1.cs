    using (StreamReader sr = new StreamReader(@"C:\temp\inputs.json"))
    {
        string json = sr.ReadToEnd();
        Wrapper f = JsonConvert.DeserializeObject<List<Wrapper>>(json).FirstOrDefault();
        // saving inputs to list
        if (f != null)
        {
            List<Dependency> dep = new List<Dependency>();
            foreach (Dependency t in f.Inputs)
            {
                dep.Add(t);
            }
            Dictionary<string, List<string>> startPoint = new Dictionary<string, List<string>>();
            foreach (var a in f.Inputs)
            {
                string[] list = a.Input.Trim().Split(' ');
                startPoint.Add(list.First(), list.ToList());
            }
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (var k in startPoint)
            {
                dict.Add(k.Key, GetDependenciesFrom(startPoint, k.Key));
            }
            // Just to print results
            foreach (var key in dict)
            {
                Console.Write(key.Key + ": ");
                foreach (var val in key.Value)
                {
                    Console.Write(val + " ");
                }
                Console.Write("\n");
            }
        }
    }
