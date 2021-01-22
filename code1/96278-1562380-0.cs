    var projects = 
        from p in xDoc.Root.Elements("Project")
        select new Project(Int32.Parse(project.Element("Id").Value, 
                                       CultureInfo.InvariantCulture),
                           p.Element("Name").Value,
                           p.Element("Description").Value,
                           p.Element("ScreenshotList")
                            .Element("Thumb").Value,
                           p.Element("ScreenshotList")
                            .Elements("Screenshot")
                            .Select(ss => 
                                new Screenshot(ss.Element("Path").Value,
                                               ss.Element("Description").Value))
                          );
