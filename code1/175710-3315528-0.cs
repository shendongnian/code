    static Type Identify<T>(IEnumerable<T>) {return typeof(T);}
    ...
    var t1= Identify(bigData1), t2= Identify(bigData2);
    if(t1 == t2) {
        Console.WriteLine("they're the same");
    } else {
        var props1 = t1.GetProperties(), props2 = t2.GetProperties();
        if(props1.Length != props2.Length) {
            Console.WriteLine(props1.Length + " vs " + props2.Length);
        } else {
            Array.Sort(props1, p => p.Name);
            Array.Sort(props2, p => p.Name);
            for(int i = 0 ; i < props1.Length ; i++) {
                if(props1[i].Name != props2[i].Name)
                    Console.WriteLine(props1[i].Name + " vs " + props2[i].Name);
                if(props1[i].PropertyType != props2[i].PropertyType)
                    Console.WriteLine(props1[i].PropertyType + " vs " + props2[i].PropertyType );
            }
        }
    }
