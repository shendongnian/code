     var inputData = new List<Test>
                {
                    new Test{Name ="A1", Parameter="P1", Value="X"},
                    new Test{Name ="A1", Parameter="P2", Value="Y"},
                    new Test{Name ="A2", Parameter="P1", Value="XX"},
                    new Test{Name ="A2", Parameter="P2", Value="YY"}
                };
    
                var groupedData = inputData.GroupBy(x => x.Parameter).ToList();
                var result = new List<foo>();
                foreach (var item in groupedData)
                {
                    result.Add(new foo
                    {
                        Name = item.FirstOrDefault().Name,
                        Value1 = item.FirstOrDefault().Value,
                        Value2 = item.Skip(1).FirstOrDefault().Value
                    });
                }
