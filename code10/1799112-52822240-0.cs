    var input = @"#start
    Line 1
    Line 2
    Line 3
    #end
    #start
    Line 4
    Line 5
    Line 6
    #end";
    var reges = new Regex("#start(.*?)#end", RegexOptions.Singleline);
    var blocks = reges.Matches(input).Cast<Match>();
    foreach (var block in blocks)
        Console.WriteLine(block.Groups[1].Value);
