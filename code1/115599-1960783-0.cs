    List<string> list = new List<string>();    
    list.Add("A");
    list.Add("B");
    List<string> list1 = new List<string>();    
    list.Add("a");
    list.Add("b");
    string xxx = "";
    for (int i = 0; i < list.Count; i++)
    {
        xxx += list[i];
        Console.WriteLine(xxx);
        // print another list items.
        for (int j = 0; j < list1.Count; j++)
        {
            Console.WriteLine("/" + list[i] + "/" + list1[j]);
        }
    }
