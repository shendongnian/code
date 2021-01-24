        List<dynamic> l = new List<dynamic>();
        dynamic d1 = 1;
        dynamic d2 = (Int16)1;
        
        l.Add(d1);
        l.Add(d2);
        //Your code goes here
        Console.WriteLine(d1.GetType());
        Console.WriteLine(d2.GetType());
        
        l.ForEach( x => Console.WriteLine(x.GetType()));
