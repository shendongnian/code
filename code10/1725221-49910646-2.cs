    var gems = new HashSet<string>();
    gems.Add('ruby');
    gems.Add('diamond');
    if (gems.Contain(want))
    {
        Console.WriteLine($"Your wedding ring will feature your selection: {want}");
    }
    else
    {
        Console.WriteLine(""Im sorry that was not a valid selection.");
    }
