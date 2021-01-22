    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    namespace ConsoleApp1
    {
        [TestFixture]
        public class Dummy
        {
            static TestCaseData Case(int i)
                => new TestCaseData(TimeSpan.FromSeconds(2)).SetName($"Case {i}");
    
            public static IEnumerable<TestCaseData> Cases()
                => Enumerable.Range(1, 5).Select(Case);
    
            [TestCaseSource(nameof(Cases)), Parallelizable(ParallelScope.Children)]
            public void ItShouldSleep(TimeSpan t)
                => Thread.Sleep(t);
    
    
            static TestCaseData Case2(int i)
                => new TestCaseData(TimeSpan.FromSeconds(2)).SetName($"Case2 {i}");
    
            public static IEnumerable<TestCaseData> Cases2()
                => Enumerable.Range(1, 5).Select(Case2);
    
            [TestCaseSource(nameof(Cases2)), Parallelizable(ParallelScope.Children)]
            public void ItShouldSleep2(TimeSpan t)
                => Thread.Sleep(t);
        }
    
        [TestFixture()]
        public class Dummy2
        {
            static TestCaseData Case(int i)
                => new TestCaseData(TimeSpan.FromSeconds(2)).SetName($"Case {i}");
    
            public static IEnumerable<TestCaseData> Cases()
                => Enumerable.Range(1, 5).Select(Case);
    
            [TestCaseSource(nameof(Cases)), Parallelizable(ParallelScope.Children)]
            public void ItShouldSleep(TimeSpan t)
                => Thread.Sleep(t);
        }
    }
