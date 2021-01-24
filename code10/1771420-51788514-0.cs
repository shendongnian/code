    string csv = @"text,intentName,entityLabels
    1,2,null
    2,1,null
    ";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoCSVReader.LoadText(csv)
        .WithFirstLineHeader()
        .WithField("text")
        .WithField("intentName")
        .WithField("entityLabels", fieldType: typeof(int[]), nullValue: "null")
        )
    {
        using (var w = new ChoJSONWriter(sb)
            )
            w.Write(p);
    }
    
    Console.WriteLine(sb.ToString());
