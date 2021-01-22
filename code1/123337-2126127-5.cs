    // if v3, use the List<T> class!
    var arrName = new List<String>();
    arrName.Add("TOM");
    // etc...
    var counts = (from n in arrName 
                  group n by n into g 
                  select new { Name = g.Key, Count = g.Count() })
                  .OrderByDescending(x => x.Count);
    var top = counts.FirstOrDefault();
    Console.WriteLine("Name: {0}; Count: {1}", top.Name, top.Count);
