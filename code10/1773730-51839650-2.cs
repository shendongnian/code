            public IEnumerable<Strings> Index()
        {
            var list = db.Strings.Select(x => new Strings { Iid = x.Iid, Itype = x.Itype, Description = x.Description, Value = x.Value } ).AsEnumerable();
            return list;
        }
