    using System;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestDisposing("Disposable-Test");
                Console.WriteLine();
                TestFinalizing("Finalizing-Test");
    
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.Read();
            }
    
            private static void TestDisposing(string testId)
            {
                using (var disposingTest = new TestSuppressFinalize(testId))
                    PrintTesting(disposingTest);
            }
    
            private static void TestFinalizing(string testId)
            {
                var finalizingTest = new TestSuppressFinalize(testId);
                PrintTesting(finalizingTest);
            }
    
            private static void PrintTesting(TestSuppressFinalize finalizingTest)
            {
                Console.WriteLine($"Testing {finalizingTest.TestId.ToString()}");
            }
        }
    
        public class TestSuppressFinalize : IDisposable
        {
            public TestSuppressFinalize(string testId) => TestId = testId;
            public string TestId { get; }
    
            public void Dispose()
            {
                Console.WriteLine($"Disposed {TestId.ToString()}");
                GC.SuppressFinalize(this); 
            }
    
            ~TestSuppressFinalize()
            {
                Console.WriteLine($"Finalized {TestId.ToString()}");
                Dispose();
            }
        }
    }
