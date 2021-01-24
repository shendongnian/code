        IDictionary od = new OrderedDictionary();
        od["A"] = 1;
        System.Collections.Generic.IDictionary<String, Int32> dictionary = new System.Collections.Generic.Dictionary<String, Int32>();
        dictionary["B"] = 2;
        IDictionary od2 = Merge<OrderedDictionary>((OrderedDictionary)od, (System.Collections.Generic.Dictionary<String, Int32>) dictionary);
        Console.WriteLine("output=" + od2["A"]+od2["B"]+od2.GetType());
        IDictionary dictionary2 = Merge<System.Collections.Generic.Dictionary<String, Int32>>((System.Collections.Generic.Dictionary<String, Int32>)dictionary, od);
        Console.WriteLine("output=" + dictionary2["A"] + dictionary2["B"] + dictionary2.GetType());
        Console.ReadKey();
