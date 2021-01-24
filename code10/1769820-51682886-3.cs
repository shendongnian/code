            listPerson.GroupBy(x => x.ParentId).Select(x => new TreePerson()
            {
                Id = x.First(c=>c.ParentdId == x.Key).Id,
                Name = x.First(c => c.ParentId == x.Key).Name,
                Children = x.Where(c => c.ParentdId == x.Key).GroupBy(c => c.Id).Select(c 
                    => new Person()
                {
                    Id = c.Key,
                    Name = c.First(z => z.Id == c.Key).Name,
                    SubLevelPerson = c.FirstOrDefault(v=>v.ParentdId == c.Key)
                }).ToList()
            });
