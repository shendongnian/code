        public static IEnumerable<TestCaseData> Generator()
        {
            yield return new TestCaseData(new Something { SomeValue = "Hi" }, "Foo").SetName("FirstTest");
            yield return new TestCaseData(new Something { SomeValue = "Bye" }, "Bar").SetName("SecondTest");
        }
        [Test]
        [TestCaseSource(nameof(Generator))]
        public void DoSomething(Something abc, string def)
        {
            Console.WriteLine($"{abc.SomeValue},{def}");
        }
