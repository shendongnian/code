    class Lift
    {
        public int LiftID { get; set; }
        public DateTime LiftDate { get; set; }
        public IEnumerable<Person> p { get; set; }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDriver { get; set; }
    }
    public JsonResult GetDetails()
    {
        var rows = new Lift[] { //Linq-To-SQL and Linq-To-Entities replaced by an example
            new Lift{LiftID = 1, LiftDate= DateTime.Now, p = new Person[] {
                new Person{IsDriver = true,  Id = 1, Name = "David Neale"},
                new Person{IsDriver = false, Id = 2, Name = "John Smith"},
                new Person{IsDriver = false, Id = 3, Name = "Paul Jones"}
            }},
            new Lift{LiftID = 2, LiftDate= DateTime.Now, p = p = new Person[] {
                new Person{IsDriver = true,  Id = 4, Name = "Daniel Faraday"},
                new Person{IsDriver = false, Id = 2, Name = "John Smith"}
            }}
        };
        var lifts = (from r in rows
                     select new
                     {
                         ID = r.LiftID,
                         Date = r.LiftDate.ToShortDateString(),
                         Driver = r.p.Where(x => x.IsDriver)
                                     .Select(x => x.Name).Single(),
                         Passengers = r.p.Where(x => !x.IsDriver)
                                         .Select(x => x.Name)
                                         .Aggregate((x, y) => x + ", " + y)
                     }).ToList();
        return Json(lifts);
    }
