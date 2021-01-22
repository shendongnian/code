    class Vessel
    {
        public int id { get; set; }
        public string name { get; set; }
    }
...
    var vessels = new List<Vessel>() { new Vessel() { id = 4711, name = "Millennium Falcon" } };
    var ship = new Vessel { id = 4711, name = "Millencolin" };
    if (vessels.Any(vessel => vessel.id == ship.id))
        Console.Write("There can only be one!");
