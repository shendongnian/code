    Dictionary<string, SampleClass> dict =
        (from element in xDoc.Descendants("Child")
                  group element by element.Attribute("Name").Value
                      into kGrp
                      select kGrp)
                .ToDictionary(grp => grp.Key,
                grp => new SampleClass
                {
                    Start = grp.Attributes("Start").Count() > 0
                            ? grp.Attributes("Start")
                                 .ToList()[0].Value.ToString()
                            : String.Empty
                    ,End = grp.Attributes("End").Count() > 0
                            ? grp.Attributes("End")
                                 .ToList()[0].Value.ToString()
                            : String.Empty
                    ,Siblings =
                        grp.Descendants("Sibling")
                            .Attributes("Name")
                            .Select(l_Temp => l_Temp.Value).ToList()
                    ,AdditionalSiblings =
                        grp.Descendants("AdditionalSibling")
                            .Attributes("Name")
                            .Select(l_Temp => l_Temp.Value).ToList()
                    ,MissingSiblings =
                        grp.Descendants("MissingSibling")
                            .Attributes("Name")
                            .Select(l_Temp => l_Temp.Value).ToList()
                });
