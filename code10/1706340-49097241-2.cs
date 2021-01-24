    var nvc = tup.Aggregate(new NameValueCollection(),
      (seed, current) =>
      {
        seed.Add(current.Item1.ToString(), current.Item2.ToString());
        return seed;
      });
    foreach (var item in nvc)
    {
      Console.WriteLine($"Key = {item} Value = {nvc[item.ToString()]}");
    }
