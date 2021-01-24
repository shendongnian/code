    string csv = @"CODE,COMPANY NAME, DATE, ACTION
    A,My Name , LLC,2018-01-28,BUY
    B,Your Name , LLC,2018-01-25,SELL
    C,
    All Name , LLC,2018-01-21,SELL
    D,World Name , LLC,2018-01-20,BUY";
    
    string bufferLine = null;
    var reader = ChoCSVReader.LoadText(csv)
        .WithFirstLineHeader()
        .Setup(s => s.BeforeRecordLoad += (o, e) =>
        {
            string line = (string)e.Source;
            string[] tokens = line.Split(",");
    
            if (tokens.Length == 5)
            {
                //Fix the second and third value with quotes
                e.Source = @"{0},""{1},{2}"",{3}, {4}".FormatString(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4]);
            }
            else
            {
                //Fix the breaking lines, assume that some csv lines broken into max 2 lines
                if (bufferLine == null)
                {
                    bufferLine = line;
                    e.Skip = true;
                }
                else
                {
                    line = bufferLine + line;
                    tokens = line.Split(",");
                    e.Source = @"{0},""{1},{2}"",{3}, {4}".FormatString(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4]);
                    line = null;
                }
            }
        });
    
    foreach (var rec in reader)
        Console.WriteLine(rec.Dump());
    //Careful to load millions rows into DataTable
    //var dt = reader.AsDataTable();
