    string myString = ":hello:mr.zoghal:";
    string[] split = myString.Split(':');
    var somethings = split
                         .Where(s => String.IsNullOrEmpty(s) == false)
                         .Select(s => String.Format("something = {0};", s));
    Console.WriteLine(String.Join("\n", somethings.ToArray()));
