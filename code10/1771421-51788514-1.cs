    string csv = @"text,intentName,entityLabels
    1,2,null
    2,1,null
    ";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoCSVReader.LoadText(csv)
        .WithFirstLineHeader()
        .WithField("text")
        .WithField("intentName")
        .WithField("entityLabels", valueConverter: (o) => new int[] { })
        )
    {
        using (var w = new ChoJSONWriter(sb)
            )
            w.Write(p);
    }
    
    Console.WriteLine(sb.ToString());
