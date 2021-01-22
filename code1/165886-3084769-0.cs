                            using (var myDatabase = new MyDatabase(entityBuilder.ToString()))
            {
                result.A = (from a in myDatabase.ATable select new CacheLoadItem<int> { ID = a.ID, Name = a.Name, Value = a.Number }).ToList();
                result.B = (from b in myDatabase.BTable select new CacheLoadItem<string> { ID = b.ID, Name = b.Name, Value = b.Code }).ToList();
                result.C = (from c in myDatabase.CTable select new CacheLoadItem<int> { ID = c.ID, Name = c.Name, Value = c.ID }).ToList();
                result.D = (from d in myDatabase.DTable select new CacheLoadItem<int> { ID = d.ID, Name = d.Name, Value = d.Number }).ToList();
                result.E = (from e in myDatabaseETable select new CacheLoadItem<int> { ID = e.ID, Name = e.Name, Value = e.Number }).ToList();
                result.F = (from f in myDatabase.FTable select new CacheLoadItem<string> { ID = f.ID, Name = f.Name, Value = f.Number }).ToList();
                result.G = (from g in myDatabaseGTable select new CacheLoadItem<string> { ID = g.ID, Name = g.Name, Value = g.Code }).ToList();
                result.H = (from h in myDatabaseHTable select new CacheLoadItem<int> { ID = h.ID, Name = h.Name, Value = h.Number }).ToList();
                result.I = (from i in myDatabaseITable select new CacheLoadItem<int> { ID = i.ID, Name = i.Name, Value = i.Number }).ToList();
            }
