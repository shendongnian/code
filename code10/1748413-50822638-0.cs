        public class MyResult {
            public string Result;
        }
        public async void Program() {
            var Timeout = 1000;
            Task<MyResult> Assignment = GetResult();
            // two ways of getting output:
            // 1: We wait using the task library
            Task.WaitAll(new Task[] { Assignment }, Timeout);
            MyResult r1 = Assignment.Result;
            // 2: We wait using the async methods:
            MyResult r2 = await Assignment;
        }
        public async Task<MyResult> GetResult() {
            // You can find methods which by default is async, therefore not needing to start the task yourself.
            return await Task.Factory.StartNew(() => LoadFromDatabase());
        }
        private MyResult LoadFromDatabase() {
            // Just testing.
            return new Question1.StartingTasks.MyResult() { Result = "TestResult" };
        }
