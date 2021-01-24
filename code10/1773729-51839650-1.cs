    public IEnumerable<Strings> Index()
        {
            var list = db.Strings.AsEnumerable();
            return list;
        }
