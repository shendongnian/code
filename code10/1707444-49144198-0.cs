    var input = "Epoch Timestamp1,Cost1,Epoch Timestamp2,Cost2,Epoch Timestamp3,Cost3.";
    var split = input.Split(',');
    var results = new List<string>();
    for (int i = 0; i < split.Length; i+=2)
       results.Add(split[i] + " " + split[i + 1]);
    foreach (var item in results)
       Console.WriteLine(item);
