    var somekey = "Access.Application.2099";
    var lastIndex = somekey.LastIndexOf(".");
    if (lastIndex > 0)
       Console.WriteLine("We have a chance");
    var substr = somekey.Substring(lastIndex + 1);
    Console.WriteLine(substr);
    int verNum = 0;
    if (int.TryParse(substr, out verNum))
    {
       Console.WriteLine("found a version maybe : " + verNum);
    }
    else
    {
       Console.WriteLine("No cigar");
    }
