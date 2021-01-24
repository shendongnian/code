    public class ComplexObject
    {
          public string FirstName {get; set; }
          public List<string> Cars {get; set; }
    }
    var result = from p in persons
        group p.car by p.FirstName into g
        select new ComplexObject { FirstName = g.Key, Cars = g.ToList() };
