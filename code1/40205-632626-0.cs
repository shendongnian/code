              dc.MyTable
              .GroupBy(r => new
              {
                  Name = r.UserName,
                  Year = r.SomeDateTime.Year,
                  Month = r.SomeDateTime.Month
              })
              .Select(r => new
              {
                  Name = r.UserName,
                  Year = r.Year,
                  Month = r.Month,
                  Count = r.Count()
              })
              .OrderBy(r => r.Year)
              .ThenBy(r => r.Month)
              .ThenBy(r => r.Name);
