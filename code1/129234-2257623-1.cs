                           var cars = from c in xdoc.Descendants("car")
                           where
                           (c.Element("patrol").Attribute("type").Value == "oil" ||
                           c.Element("patrol").Attribute("type").Value == "gas")
                           select new Car
                           {
                               FuelType = c.Element("patrol").Attribute("type").Value.ToString()
                           };
        foreach (Car c in cars)
            {
                Console.WriteLine(c.ToString());
            }
        class Car
        {
            public string FuelType { get; set; }
            public override string ToString()
            {
                return "Car FeulType = " + this.FuelType.ToString();
            }
        }
 
             
