        [Fact]
        public void Test1()
        {
            var listOfStringList = new List<List<string>>();
            var list1 = new List<string> { "A", "B", "C" };
            var list2 = new List<string> { "AA", "BB", "CC" };
            var list3 = new List<string> { "AAA", "BBB", "CCC" };
            listOfStringList.Add(list1);
            listOfStringList.Add(list2);
            listOfStringList.Add(list3);
            var resultData = new List<List<string>>();
            listOfStringList.ForEach((stringList) =>
            {
                if (resultData.Count == 0)
                {
                    resultData = stringList.Select(u => new List<string> { u }).ToList();
                    return;
                }
                resultData = resultData.SelectMany(u => stringList
                    .Select(v =>
                    {
                        var list = new List<string>();
                        u.ForEach(sv =>
                        {
                            list.Add(sv);
                        });
                        list.Add(v);
                        return list;
                    }).ToList()).ToList();
            });
            var resultantData = resultData;
        }
