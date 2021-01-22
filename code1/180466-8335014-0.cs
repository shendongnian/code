        public class RunTests
        {
            public static void Main(string[] args)
            {
                TestResults results = Tester.RunTestsInClass<Tests>();
              
                Console.WriteLine("Tests Run: {0}", results.NumberOfResults);
                Console.WriteLine("Results {0}:PASSED {1}:FAILED", results.NumberOfPasses, results.NumberOfFails);
                Console.WriteLine("Details:");
    
                foreach (TestResult result in results)
                {
                    Console.WriteLine("Test {0}: {1} {2}",
                                                result.MethodName,
                                                result.Result,
                                                result.Result == TestResult.Outcome.Fail ? "\r\n" + result.Message : "");
                }
    
                Console.ReadLine();
            }
        }
