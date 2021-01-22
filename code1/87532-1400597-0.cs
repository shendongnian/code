    public void Method()
    {
        Dictionary<int, int> d1 = new Dictionary();
        
        d1.Add(1,1);
        d1.Add(2,3);
        
        Dictionary<int, int> d2 = d1;
        
        //this line only 'clears' d1
        d1 = new Dictionary();
        
        d1.Add(1,1);
        d1.Add(3,5);
        d2.Add(2,2);
        
        //writes '2' followed by '1'
        Console.WriteLine(d1.Count);
        Console.WriteLine(d2.Count);
    }
