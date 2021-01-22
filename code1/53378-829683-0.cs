    string strString = "AA BRA KA DABRA";
    var grp = from c in strString.ToCharArray() 
            group c by c into m
            select new { Key = m.Key, Count = m.Count() };
    
    foreach (var item in grp)
    {
        Console.WriteLine(
            string.Format("Character:{0} Appears {1} times", 
            item.Key.ToString(), item.Count));
    }
