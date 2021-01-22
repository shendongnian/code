    var burgers = new List<Cheeseburger>();
    var output = burgers.ToCsvHeader();
    output += Environment.NewLine;
    burgers.ForEach(burger =>
    {
        output += burger.ToCsvRow();
        output += Environment.NewLine;
    });
    var path = "[where ever you want]";
    System.IO.File.WriteAllText(path, output);
