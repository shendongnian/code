        var grocery = new List<groceryy>() { new groceryy { fruitId = 1, vegid = 1, name = "s" }, new groceryy { fruitId = 2, vegid = 2, name = "a" }, new groceryy { fruitId = 3, vegid = 3, name = "h" } };
        var fruit = new List<fruitt>() { new fruitt { fruitId = 1, fname = "s" }, new fruitt { fruitId = 2, fname = "a" } };
        var veggie = new List<veggiee>() { new veggiee { vegid = 1, vname = "s" }, new veggiee { vegid = 2, vname = "a" } };
        //var fruit= new List<fruitt>();
        //var veggie = new List<veggiee>();
        var result = from g in grocery
                     join f in fruit on g.fruitId equals f.fruitId into tempFruit
                     join v in veggie on g.vegid equals v.vegid into tempVegg
                     from joinedFruit in tempFruit.DefaultIfEmpty()
                     from joinedVegg in tempVegg.DefaultIfEmpty()
                     select new { g.fruitId, g.vegid, fname = ((joinedFruit == null) ? string.Empty : joinedFruit.fname), vname = ((joinedVegg == null) ? string.Empty : joinedVegg.vname) };
        foreach (var outt in result)
            Console.WriteLine(outt.fruitId + "  " + outt.vegid  + "  " + outt.fname  + "  " + outt.vname);
        
    }
}
    public class groceryy
    {
        public int fruitId;
        public int vegid;
        public string name;
    
    
    }
    public class fruitt
    {
        public int fruitId;
        public string fname;
    
    
    }
    public class veggiee
    {
        public int vegid;
        public string vname;
    
    
    }
