     var valuations = el.Element("Valuations").Elements("vehicleValuation");
     var carNodes = el.Elements("propertyAuto");
     var cars = carNodes.Select(x => 
                    new {
                         id = x.Attribute("id").Value,
                         PropertyValues = x.Element("Values").Elements("propertyValue").
                                            SelectMany(
                                                    y => valuations.Where( 
                                                            val => val.Attribute("id").Value == y.Attribute("idRef").Value
                                                                          ).Select( valuation => 
                                                                              new { 
                                                                                    Type = valuation.Attribute("valuationType"),
                                                                                    EstVal = valuation.Attribute("estimatedValue")
                                                                                  }
                                                                                  )
                                                   )
                         });
