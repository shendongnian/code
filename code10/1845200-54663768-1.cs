    ThermalConstantHeat = 
         (int)line.Element("ThermalConstantHeat"),
         Vertices = line.Element("Vertices").Descendants("Point").Select(p => new TokenController.Point
         {
             X = (decimal)p.Element("X"),
             Y = (decimal)p.Element("Y")//can't access Element
         }).ToList()
