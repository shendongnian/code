    var answer = accountTable.Aggregate(new { Min = int.MinValue, Max = int.MaxValue }, 
                                            (a, b) => new { Min = Math.Min(a.Min, b.Field<int>("AccountLevel")),
                                                            Max = Math.Max(a.Max, b.Field<int>("AccountLevel")) });
    int min = answer.Min;
    int max = answer.Max;
