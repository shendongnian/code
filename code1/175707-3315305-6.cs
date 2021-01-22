    foreach (var item in ForEachHelper.Wrap(collection))
    {
        Console.WriteLine("Position=" + item.Index.ToString());
        Console.WriteLine("Current=" + item.Current.ToString());
        if (item.HasNext)
        {
            Console.WriteLine("Next=" + item.Next.ToString());
        }
    }
