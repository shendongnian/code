    var carProperties = from propertyAuto in data.Descendants("propertyAuto")
                        select new
                        {
                            Id = propertyAuto.Attributes("id").First().Value,
                            Properties = from property in propertyAuto.Descendants("propertyValue")
                                         join value in data.Descendants("vehicleValuation")
                                         on property.Attribute("idRef").Value
                                         equals value.Attribute("id").Value
                                         select new
                                         {
                                             Value = value.Attribute("estimatedValue").Value,
                                             Type = value.Attribute("valuationType").Value,
                                             PropertyID = property.Parent.Parent.Attribute("id").Value
                                         }
                        };
    var cars = from car in carProperties
               select new
               {
                   Id = car.Id,
                   Auto = car.Properties.Where(x => x.Type == "Auto").Select(x => x.Value).First(),
                   Book = car.Properties.Where(x => x.Type == "Book").Select(x => x.Value).First()
               };
