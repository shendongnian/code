                           var cars = from c in xdoc.Descendants("car")
                           where
                           (c.Element("patrol").Attribute("type").Value == "oil" ||
                           c.Element("patrol").Attribute("type").Value == "gas")
                           select new Car
                           {
                               FuelType = c.Element("patrol").Attribute("type").Value.ToString()
                           };
 
                           class Car  
                           { 
                                 public string FuelType { get; set; }
                           }     
    
