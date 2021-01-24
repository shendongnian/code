    static void Main(string[] args) {
        List<int> numbers = new List<int>() { 0, 1, 2, 3, 4 };
        Dictionary<int, List<TestClass>> testAllYearsList = new Dictionary<int, List<TestClass>>();
        int year = 2018;
        var random = new Random();
        foreach (var number in numbers) {
            List<TestClass> testList = new List<TestClass> {
                new TestClass { test = 0.2 },
                new TestClass { test = 1.5 }
            };
            testList.ForEach(x => {
                x.test = random.NextDouble();
            });
            testAllYearsList.Add(year - number, testList);
        }
        foreach (KeyValuePair<int, List<TestClass>> entry in testAllYearsList) {
            foreach (var xx in entry.Value) {
                Console.WriteLine(entry.Key + "-------" + xx.test);
            }
        }
    }
