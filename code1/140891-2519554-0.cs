        static void Mainthread()
        {
            List<string> input = new List<string>();  // fill with data
            int half = input.Count() / 2;
            ManualResetEvent event1 = new ManualResetEvent(false);
            List<string> results1 = null;
            // give the first half of the input to the first thread
            ThreadPool.QueueUserWorkItem(r => ComputeTask(input.GetRange(0, half), out results1, event1));
            ManualResetEvent event2 = new ManualResetEvent(false);
            List<string> results2 = null;
            // second half of input to the second thread
            ThreadPool.QueueUserWorkItem(r => ComputeTask(input.GetRange(half + 1, input.Count() - half), out results2, event2));
            // wait for both tasks to complete
            WaitHandle.WaitAll(new WaitHandle[] {event1, event2});
            // combine the results, preserving order.
            List<string> finalResults = new List<string>();
            finalResults.AddRange(results1);
            finalResults.AddRange(results2);
        }
        static void ComputeTask(List<string> input, out List<string> output, ManualResetEvent signal)
        {
            output = new List<string>();
            foreach (var item in input)
            {
                // do work here
                output.Add(item);
            }
            signal.Set();
        }
