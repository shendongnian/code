    static Dictionary<string,int> CountUses = new Dictionary<string, int>();
      /* do this once  - so they always print in order*/
            CountUses.Add("", 0);
            CountUses.Add("7", 0);
            CountUses.Add("Glocke", 0);
            CountUses.Add("Melone", 0);
            CountUses.Add("Pflaume", 0);
            CountUses.Add("Orange", 0);
            CountUses.Add("Zitrone", 0);
            CountUses.Add("Kirche", 0);
    /* use this in your function */
    if (!CountUses.ContainsKey(s.Text))
         CountUses.Add(s.Text, 0);
    
     CountUses[s.Text]++;
