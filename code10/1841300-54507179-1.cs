    var itemSign = Sign(data.FirstOrDefault());
    var result = new List<int>();
    foreach (var item in data)
    {
        if (itemSign == Sign(item))
        {
            result.Add(item);
            Console.WriteLine(item);
        }
        else
            break;
        itemSign = Sign(item);
    }
