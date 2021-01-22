    public ActionResult Action(string[] filters)
    {
        /*This values are provided by the user, maybe its better to use
         an ID instead of the name, but for the example is OK.
         filters will be something like : string[] filters = {"America", "Europe", "Africa"};
        */
        List<Location> LocationList = FindAllMatchingRegions(filters);
        return View(LocationList);
    }
    public List<Location> FindAllMatchingRegions(string[] filters)
            {
                var db = Session.Linq<Location>();
                var expr = PredicateBuilder.False<Location>(); //-OR-
                foreach (var filter in filters)
                {
                    string temp = filter;
                    expr = expr.Or(p => p.Region.Name == filter);
                }
    
                return db.Where(expr).ToList();
            }
