            List<MyObject> tests = new List<MyObject>() 
            { 
                new MyObject {Name = "A", Number = 2 },
                new MyObject {Name = "A", Number = null },
                new MyObject {Name = "B", Number = null},
                new MyObject {Name = "C", Number = null},
                new MyObject {Name = "C", Number = null},
                new MyObject {Name = "D", Number = 4}
            };
            var qry = from t in tests
                      group t by t.Name into g
                      select g.Max();
            qry.ToList();
