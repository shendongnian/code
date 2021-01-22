                using (var myDatabase = new MyDatabase(entityBuilder.ToString()))
            {
                result.A = (from a in myDatabase.ATable select a).ToList().Select(b => new CacheLoadItem<int> { ID = a.ID, Name = a.Name, Value = a.Number }).ToList();
                result.B = (from b in myDatabase.BTable select b).ToList().Select(b=>new CacheLoadItem<string> { ID = b.ID, Name = b.Name, Value = b.Code }).ToList();
                result.C = (from c in myDatabase.CTable select c).ToList().Select(c=> new CacheLoadItem<int> { ID = c.ID, Name = c.Name, Value = c.ID }).ToList();
                result.D = (from d in myDatabase.DTable select d).ToList().Select(d=> new CacheLoadItem<int> { ID = d.ID, Name = d.Name, Value = d.Number }).ToList();
                result.E = (from e in myDatabaseETable select e).ToList().Select(e=> new CacheLoadItem<int> { ID = e.ID, Name = e.Name, Value = e.Number }).ToList();
                result.F = (from f in myDatabase.FTable select f).ToList().Select(f => new CacheLoadItem<string> { ID = f.ID, Name = f.Name, Value = f.Number }).ToList();
                result.G = (from g in myDatabaseGTable select g).ToList().Select(g=> new CacheLoadItem<string> { ID = g.ID, Name = g.Name, Value = g.Code }).ToList();
                result.H = (from h in myDatabaseHTable select h).ToList().Select(h=> new CacheLoadItem<int> { ID = h.ID, Name = h.Name, Value = h.Number }).ToList();
                result.I = (from i in myDatabaseITable select i).ToList().Select(i=> new CacheLoadItem<int> { ID = i.ID, Name = i.Name, Value = i.Number }).ToList();
            }
