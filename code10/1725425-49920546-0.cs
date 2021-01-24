    var ListA = new List<Your_Class>() { 
             new Your_Class{ Code = "OA", Ref ="001",StartDate=Convert.ToDateTime ("01.01.2000")},
             new Your_Class{ Code = "OA", Ref ="001",StartDate=Convert.ToDateTime("01.01.2000")},
    		 new Your_Class{ Code = "OA", Ref ="001",StartDate=Convert.ToDateTime("12.01.2001")},
    		 new Your_Class{ Code = "OB", Ref ="002",StartDate=Convert.ToDateTime("01.01.2000")}
    };
    var ListB =  from c in ListA
                 group c by c.Code into grp
                 select grp.OrderByDescending(c => c.StartDate).FirstOrDefault();
    foreach(Your_Class your_cls in ListB) {
    		  Console.WriteLine(your_cls.Code+" "+your_cls.Ref+" "+ your_cls.StartDate.ToString("dd.MM.yyyy"));
    }
