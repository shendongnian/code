    foreach (var number in numbers)
            {
                var newTestList = new List<TestClass>();
                foreach (var xx in testList)
                {
                    newTestList.Add(new TestClass
                    {
                        name = xx.name,
                        test = xx.test
                    });
                }
                newTestList.ForEach(x => {
                    x.test = random.NextDouble();
                });
                testAllYearsList.Add(year - number, newTestList);
            }
