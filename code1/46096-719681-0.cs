    var b = lst.Where(f => f.A > 3)
               .Aggregate(
                      // seed, initial values
                      new
                      {
                         MinA = int.MaxValue,
                         MaxB = int.MinValue
                      },
                      // accumulator function
                      (a,f) => new
                      {
                         MinA = Math.Min(a.MinA , f.A),
                         MaxB = Math.Max(a.MaxB , f.B)
                      });
