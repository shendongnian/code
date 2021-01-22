    string txt = "Lore ipsum {{abc|prop1=\"asd\";prop2=\"bcd\";}} asd lore ipsum";
    Regex r = new Regex("{{(?<single>([a-z0-9]*))\\|((?<pair>([a-z0-9]*=\"[a-z0-9]*\";))*)}}", RegexOptions.Singleline | RegexOptions.IgnoreCase);
    Match m = r.Match(txt);            
    if (m.Success)
    {
        Console.WriteLine(m.Groups["single"].Value);
        foreach (Capture cap in m.Groups["pair"].Captures)
        {
            Console.WriteLine(cap.Value);
        }
    }
