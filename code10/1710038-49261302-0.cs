        var resultSet1 = collection2.Join(collection1, a => a.ID, b => b.ID, (a, b) => new { a, b })
              .ToList()
              .Select(s => new ViewModel.Customer()
              {
                  ID = s.b.ID,
                  FirstName = s.b.FirstName,
                  LastName = s.b.LastName
              }).ToList();
        var resultSet2 = collection1.Join(collection2, a => a.ID, b => b.ID, (a, b) => new { a, b })
                .ToList()
                .Select(s => new ViewModel.Customer()
                {
                    ID = s.b.ID,
                    FirstName = s.b.FirstName,
                    LastName = s.b.LastName
                }).ToList();
        return resultSet1.Union(resultSet2);
