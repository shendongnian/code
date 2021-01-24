    Boolean x = false;
    Dictionary<string, dynamic> k = new Dictionary<string, dynamic>();
    k.Add("Param1", x.ToString().ToLower());
    k.Add("Param2", 123);
    Console.WriteLine(string.Format("hi {0} -- {1}", k.Values.ToArray()));
