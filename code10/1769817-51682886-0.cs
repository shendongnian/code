            listPerson.GroupBy(x => x.Id).Select(x => new TreePerson()
            {
                Id = x.Key,
                Name = x.First(c => c.Id == x.Key).Name,
                Children = x.Where(c => c.ParentdId == x.Key).GroupBy(c => c.Id).Select(c 
                    => new Person()
                {
                    Id = c.Key,
                    Name = c.First(z => z.Id == c.Key).Name,
                    SubLevelPerson = c.FirstOrDefault(v=>v.ParentdId == c.Key)
                }).ToList()
            });
