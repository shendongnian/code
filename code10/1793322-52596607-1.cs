    List<TestClass> items = new List<TestClass>
            {
                new TestClass
                {
                    Name = "T1",
                    LoggedDate = new DateTime(2018, 9,29 , 10, 10, 03, 014)
                },
                new TestClass
                {
                    Name = "T1",
                    LoggedDate = new DateTime(2018, 9, 29, 10, 10, 03, 120)
                },
                new TestClass
                {
                    Name = "T1",
                    LoggedDate = new DateTime(2018, 9, 29, 10, 10, 04, 012)
                },
                new TestClass
                {
                    Name = "T1",
                    LoggedDate = new DateTime(2018, 9, 29, 11, 10, 04, 014)
                },
                new TestClass
                {
                    Name = "T1",
                    LoggedDate = new DateTime(2018, 9, 29, 11, 10, 04, 220)
                },
                new TestClass
                {
                    Name = "T1",
                    LoggedDate = new DateTime(2018, 9, 29, 11, 10, 04, 014)
                },
                new TestClass
                {
                    Name = "T1",
                    LoggedDate = new DateTime(29, 9, 29, 10, 11, 05, 014)
                }
            };
    
           List<TestClass> resultList = new List<TestClass>();
           for (int i = 0; i < items.Count-1; i++)
            {
               
                    if (items[i].LoggedDate.Minute - items[i + 1].LoggedDate.Minute == -1)
                    {
                        resultList.Add(items[i]);
                        resultList.Add(items[i + 1]);
                        break;
                    }             
            }
