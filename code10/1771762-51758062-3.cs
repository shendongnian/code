    bool isEqual = Console.ReadLine()
                          .ToCharArray()
                          .Select(i => Convert.ToInt32(i.ToString()))
                          .Zip(Console.ReadLine()
                                      .ToCharArray()
                                      .Select(i => Convert.ToInt32(i.ToString())),
                               (i, j) => new
                               {
                                   First = i,
                                   Second = j,
                                   Total = i + j
                               })
                          .GroupBy(x => x.Total)
                          .Select(x => x.First().Total)
                          .Count() == 1;
