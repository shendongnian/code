    using System.Collections.Generic;
    using System.Threading;
    
    namespace noocyte.Threading
    {
        class CalcState
        {
            public CalcState(ManualResetEvent reset, string input) {
                Reset = reset;
                Input = input;
            }
            public ManualResetEvent Reset { get; private set; }
            public string Input { get; set; }
        }
        class CalculateMT
        {
            List<string> result = new List<string>();
            List<ManualResetEvent> events = new List<ManualResetEvent>();
    
            private void Calc() {
                List<string> aList = new List<string>();
                aList.Add("test");
    
                foreach (var item in aList)
                {
                    CalcState cs = new CalcState(new ManualResetEvent(false), item);
                    events.Add(cs.Reset);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Calculate), cs);
                }
                WaitHandle.WaitAll(events.ToArray());
            }
    
            private void Calculate(object s)
            {
                CalcState cs = s as CalcState;
                cs.Reset.Set();
                result.Add(cs.Input);
            }
        }
    }
