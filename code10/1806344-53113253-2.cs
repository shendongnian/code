    var l  = new List<string>()
    {
       "c:\\dev\\Batch 1.10.18.xlsx", 
       "c:\\dev\\Batch 2.10.18.xlsx", 
       "c:\\dev\\Batch 31.10.18.xlsx
    };
		
    var ci = CultureInfo.GetCultureInfo("fr-FR"); // pick culture is same as pick format. You need to pre-define one
    var r = l.Select(x=>new{name = x, parts = Path.GetFileNameWithoutExtension(x).Split(" .".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)}).
			Select(a=> new {name = a.name, date = DateTime.Parse(a.parts[1] + "/" + a.parts[2] + "/" + a.parts[3], ci)}).
            OrderBy(x => x.date); //OrderByDescending(x => x.date);
		
    r.ToList().ForEach(x => Console.WriteLine(x.name));
