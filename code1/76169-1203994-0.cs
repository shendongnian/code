    string myString = ":hello:mr.zoghal:";
    string[] split = myString.Split(new Char[] { ':' });
    var somethings = split
                         .Where(s => String.IsNullOrEmpty(s) == false)
                         .Select(s => String.Format("Something = {0}", s));
    Console.WriteLine(String.Join(" ; ", somethings.ToArray()));
