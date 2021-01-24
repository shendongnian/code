    public static double GetFxRate(DateTime dt)    
    {
      DBEntities dbe = new DBEntities ();
    var fx_rate = dbe.MyTable.Where (s => s.Currency == "aaaaaaaaa" && s.Date == dt).FirstOrDefault( s => (s.ask + s.bid)/2);
    return Convert.ToDouble(fx_rate);
    }
