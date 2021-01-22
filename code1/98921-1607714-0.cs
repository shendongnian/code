            var people = new List<Person>();
            var q = from p in people
                    group p by p.AreaId into g
                    select new { Id = g.Key, Total = g.Count() };
            people.Add(new Person { AreaId = 1, Name = "Alex" });
            people.Add(new Person { AreaId = 1, Name = "Alex" });
            people.Add(new Person { AreaId = 2, Name = "Alex" });
            people.Add(new Person { AreaId = 3, Name = "Alex" });
            people.Add(new Person { AreaId = 3, Name = "Alex" });
            people.Add(new Person { AreaId = 4, Name = "Alex" });
            people.Add(new Person { AreaId = 2, Name = "Alex" });
            people.Add(new Person { AreaId = 4, Name = "Alex" });
            people.Add(new Person { AreaId = 1, Name = "Alex" });
            foreach (var item in q)
            {
                Console.WriteLine("AreaId: {0}, Total: {1}",item.Id,item.Total);
            }
