    var q = from c in CUS_Contact
            join cp in CUS_Phone_JCT on c.Id equals cp.Contact_Id into cp2 
            from cp3 in cp2.DefaultIfEmpty()
            group new { c, cp3.Phone.Phone } by c.Id into g
            let c = g.First().c
            select new {
                           c.Id,
                           c.Cus_Id, 
                           c.Namefirst, 
                           c.Namemiddle, 
                           c.Namelast, 
                           Phones = g.Select(x => x.Phone)
                           c.Title, 
                           c.Dept, 
                           c.Des, c.Datecreate, 
                           c.Dateupdate, 
                           c.Usr_idcreate, 
                           c.Usr_idupdate
                       };
    
    foreach(var v in q) {
        Console.WriteLine(v.Id + "-" + v.Namefirst);
        foreach(var p in v.Phones) {
            Console.WriteLine(" -" + p);
        }
    }
