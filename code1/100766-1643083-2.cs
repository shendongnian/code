    using HugeType = System.Collections.Generic.Dictionary<int, string>; // Example 'typedef'
    ...
    
    //Create class, note the 'typedef' HugeType
    MyClass<List<HugeType>, HugeType> myclass = new MyClass<List<HugeType>, HugeType>();
    //Fill it
    HugeType hugeType1 = new HugeType();
    hugeType1.Add(1, "First");
    hugeType1.Add(2, "Second");
    HugeType hugeType2 = new HugeType();
    hugeType1.Add(3, "Third");
    hugeType1.Add(4, "Fourth");
    myclass.Store(hugeType1);
    myclass.Store(hugeType2);
    //Show it's values.
    myclass.Items.ForEach(element => element.Values.ToList().ForEach(val => Console.WriteLine(val)));
