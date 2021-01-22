    List<string> items1 = new List<string>();
    items1.Add("cake");
    items1.Add("cookie");
    items1.Add("pizza");
    List<string> items2 = new List<string>();
    items2.Add("pasta");
    items2.Add("pizza");
    var results = from item in items1
    		  where items2.Contains(item)
    		  select item;
    foreach (var item in results)
        Console.WriteLine(item); //Prints 'pizza'
