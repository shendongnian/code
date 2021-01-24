    public static IDictionary<string, Spell> elementStatus = new[]
        {
         new Spell("Fire", "Burn", 0.5),
         new Spell("Lightning", "Shock", 0.5),
         //etc... (25 more)
       }.ToDictionary(x=>x.Name,y=>y);
