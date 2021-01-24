    var result = dbContext.T1
        // don't take all T1 items, but only the ones where:
        .Where(t1 => t1.col2 > 300
                  && t1.col3 != 1
                  && t1.col4 != 285
                  && t1.col5 != 830
                  && t1.col6 > 0
        // join the remaining t1s with table T3
        .Join dbContext.T3,
              t1 => t1.Id,               // from every T1 take the id
              t3 => t3.Id,               // from every T3 take the id
              // ResultSelector: take a t1 and a matching t3 to create one new object
              (t1, t3) => new MyModel
              {
                  Id = t1.Id,
                  // IsFunc2: true if Table2 has any element with Id equal to t1.Id and col values
                  IsFunc2 = dbContext.Table2
                            .Where(t2 => t2.ID == t1.Id
                                      && (t2.col1 > 0 || t2.col2 != "" || t2.col3 != ""))
                            .Any();
        });
