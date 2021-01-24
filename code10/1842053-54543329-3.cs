    void FillDatabase(IEnumerable<Line> lines)
    {
        // convert the lines into a sequence or Roots with their As,
        // with their Bs, with their Cs, ...
        IEnumerable<Root> roots = lines.GroupBy(line => line.Root,
            (root, linesOfThisRoot) => new Root
            {
                Name = root.Name,
                ... other root properties
                As = linesOfThisRoot.GroupBy(line => line.A,
                (a, linesWithRootAndA) => new A
                {
                    Name = a.Name,
                    ... other a properties
                    Bs = linesWithRootAndA.GroupBy(line => line.B,
                         (b, linesWithRootAB) => new B
                         {
                            ... B properties
                            Cs = linesWithRootAB.GroupBy(line => line.C,
                            {
                               etc.
                            })
                            .ToList(),
                        })
                        .ToList(),
                   })
                   .ToList(),
                })
                .ToList();
            });
        using (var dbContext = new MyDbContext()
        {        
            dbContext.Roots.AddRange(roots.ToList());
            dbContext.SaveChanges();
        }
    }
