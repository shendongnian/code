    var lists = new List<List<double>>
    {
        new List<double> {1.0, 2.0},
        new List<double> {3.0, 4.0}
    };
    var test = (lists, "test");
    Console.Write(JsonConvert.SerializeObject(test));
