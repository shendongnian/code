    var list = new List<int>() { 1, 2, 3, 4 };
    var listAsString = String.Join("", list.ConvertAll(x => x.ToString()).ToArray());
    Console.WriteLine(listAsString);
    int result = Int32.Parse(listAsString);
    Console.WriteLine(result);
