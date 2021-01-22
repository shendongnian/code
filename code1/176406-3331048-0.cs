    var query = from states in xml.Elements()
                        select new State
                        {
                            Children = from cities in states.Elements()
                                       select new City()
                                        {
                                            ParentState = new State{
                                                Property1 = states.XElement("Property1").Value
}
                                        }
                        };
