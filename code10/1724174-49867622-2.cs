    var music = xdoc.Descendants().Where(x => x.Name == "music");
    xdoc.Descendants().Where(x =>
        !music.AncestorsAndSelf().Contains(x)
        && !music.Descendants().Contains(x)
    ).Remove();
    Console.WriteLine(xdoc.ToString());
