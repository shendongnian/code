    Dictionary<int, string> startingpoints = xml.Elements(ns + "startingPoint")
            .Select(sp => new { 
                                  Player = (int)(sp.Attribute("player")), 
                                  Coordinates = Coordinate.FromString((string)(sp.Attribute("coordinates"))) 
                              })
            .ToDictionary(sp => sp.Player, sp => sp.Coordinates);
