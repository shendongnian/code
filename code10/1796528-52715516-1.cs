    public class Difference
    {
        public int Id {get;set;}
        public string Val1 {get;set;}
        public string Val2 {get;set;}
        public string Val3 {get;set;}
        public string Val4 {get;set;}
        public string Val5 {get;set;}
    }
    
    var result = new List<Difference>();
    var props = typeof(Difference).GetProperties();
    foreach(var origin in source)
    {
        var against = updated.FirstOrDefault(x => x.Id == origin.Id);
        if(against != null)
        {
            var diff = new Difference{ Id = origin.Id };
            var add = false;
            foreach(var prop in props)
            {
                var againstVal = prop.GetValue(against);
                if(prop.GetValue(origin) != againstVal)
                {
                    prop.SetValue(diff, againstVal)
                    add = true;
                }
            }
            if(add)
                result.Add(diff);
        }
    }
    foreach(var res in result)
    {
        foreach(var prop in props)
        {
            var val = prop.Value;
            if(val != null)
                Console.Write($"{prop.Name}:{prop.Value} ")
        }
        Console.WriteLine();
    }
    //output:
    //Id:1 Val2:C Val4:F
    //Id:2 Val2:C Val3:F Val13:S
    //...
