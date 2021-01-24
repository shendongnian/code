            listPerson.Where(x => x.ParentdId == null).Select(x => new TreePerson()
            {
                Id = x.Id,
                Name = x.Name,
                Children = listPerson.Where(c => c.ParentdId == x.Id).GroupBy(c => c.Id).Select(c => new Person()
                {
                    Id = c.Key,
                    Name = c.First(z => z.Id == c.Key).Name,
                    SubLevelPerson = c.FirstOrDefault(v => v.ParentdId == c.Key)
                }).ToList()
            });
