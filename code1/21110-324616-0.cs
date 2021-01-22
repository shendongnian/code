    var choiceList = myXDoc.Root
                           .Element("BetaSection")
                           .Descendants("Choices")
                           .Select(element => new
                                   {
                                      Name = element.Attribute("id").Value,
                                      Data = element.Value;
                                   });
