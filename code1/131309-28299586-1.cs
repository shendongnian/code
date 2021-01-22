    var burgers = new List<Cheeseburger>();
    var output = burgers.ToCsvHeader();
    burgers.ForEach(burger =>
    {
        output += burger.ToCsvRow();
    });
    var path = "[where ever you want]";
    System.IO.File.WriteAllText(path, output);
