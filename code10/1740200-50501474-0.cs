	//Assuming your dataDump is something like follows.
    var dataDump = new Dictionary<string, string>();
    dataDump.Add("Property1", "Value1");
    dataDump.Add("Property2", "Value2");
    dataDump.Add("Property3", "Value3");
    Model m = new Model();
    var properties = m.GetType().GetProperties();
    foreach(var p in properties){
        if (dataDump.Keys.Contains(p.Name)) { 
            var val = dataDump[p.Name];
            p.SetValue(m, val);
        }
    }
    Console.WriteLine(m.Property1);
    Console.WriteLine(m.Property3);
    Console.ReadLine();
