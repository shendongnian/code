    XmlTextReader reader = new XmlTextReader(@"c:\temp\frames.xml");
    var people = new List<Person>();
    var person = new Person();
    
    while (reader.Read())
    {
        if (reader.IsStartElement())
        {
            switch (reader.Name)
            {
                case "FrameSet":
                    var id = reader.GetAttribute("PersonId");
                    if (!people.Any(p => p.PersonId == id))
                    {
                        person = new Person { PersonId = id, TeamId = reader.GetAttribute("TeamId") };
                        people.Add(person);
                    }
                    else
                    {
                        person = people.First(p => p.PersonId == id);
                    }
                    break;
                case "Frame":
                    var n = reader.GetAttribute("N");
                    var x = reader.GetAttribute("X");
                    var y = reader.GetAttribute("Y");
                    var s = reader.GetAttribute("S");
                    person.Frames.Add(new Frame { N = n, X = x, Y = y, S = s });
                    break;                        
            }
        }
    }
