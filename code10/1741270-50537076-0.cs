    var res = _initialCollection.GroupBy(x => new { x.StudentId })
                                .Select(x => new 
                                {
                                  StudentId=  x.Key,
                                  Sum = x.Sum(y => AppVariable.EnumToNumber(y.Scores))
                                  x.First().FName
                                }).ToList();
