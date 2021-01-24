            var list1 = new List<TestResult> {
                new TestResult("1", new List<object> { 1,2,3 }),
                new TestResult("2", new List<object> { 4,5,6 })
            };
            var list2 = new List<TestResult> {
                new TestResult("1", new List<object> { 1,2,3 }),
                new TestResult("2", new List<object> { 4,5,6 })
            };
            var test = ReturnIncorrectTestLabels(list1, list2);
