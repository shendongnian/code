    List<string> list = new List<string>
    {
    "Value1, 2010-06-28 10:30:00.000",
    "Value2, 2010-06-27 10:30:00.000",
    "Value3, 2010-06-26 10:30:00.000"
    };
    list.Sort((a, b) =>
        {
            string[] aSplit = a.Split(',');
            string[] bSplit = b.Split(',');
 
            if (aSplit.Count() < 2 && bSplit.Count() < 2) 
                return a.CompareTo(b);
            DateTime date1, date2;
                              
            if (!DateTime.TryParse(aSplit[1].Trim(), out date1) || 
                !DateTime.TryParse(bSplit[1].Trim(), out date2))
                return a.CompareTo(b);
            return date2.CompareTo(date1);
        });
