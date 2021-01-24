    char delimited = ',';
    var inputCSV = @"Skip it
    Skip ita
    Skip it
    Col1,Col2,Foo,Bar
    2.3,0.2,3.0,40.5
    2.3,0.2,3.0,40.5
    2.3,0.2,3.0,40.5";
    var fileReadLinesMimic = inputCSV
                        .Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    var data = fileReadLinesMimic
                .Skip(4)
                .Select(line => line.Split(new Char[] { delimited }, StringSplitOptions.RemoveEmptyEntries))
                .Select(chunk =>
                    chunk.Select(x => Double.Parse(x, CultureInfo.InvariantCulture)
                )
                .ToArray());
    foreach (var item in data)
    {
        Console.WriteLine($"Col1={item[0]}; Col2={item[1]}; Foo={item[2]}; Bar={item[3]};");
    }
