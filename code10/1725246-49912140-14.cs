    using System;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
            private const string DisposableTestId = "Disposable-Test";
            private const string FinalizingTestId = "Finalizing-Test";
    
            static void Main(string[] args)
            {
                TestDisposing();
                Console.WriteLine();
                TestFinalizing();
    
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.Read();
            }
    
            private static void TestDisposing()
            {
                using (var disposingTest = new TestSuppressFinalize(DisposableTestId))
                    PrintTesting(disposingTest);
            }
    
            private static void TestFinalizing()
            {
                var finalizingTest = new TestSuppressFinalize(FinalizingTestId);
                PrintTesting(finalizingTest);
            }
    
            private static void PrintTesting(TestSuppressFinalize finalizingTest)
                => Console.WriteLine($"Testing {finalizingTest.TestId.ToString()}");
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
