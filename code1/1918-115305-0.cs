    class Program {
          static void Main(string[] args) {
    
             var p = new { FirstName = "Bill", LastName = "Gates" };
    
             var tests = new[] {
                new { Name = "Concat", Action = new Action(delegate() { string x = p.FirstName + " " + p.LastName; }) },
                new { Name = "Format", Action = new Action(delegate() { string x = string.Format("{0} {1}", p.FirstName, p.LastName); }) },
                new { Name = "StringBuilder", Action = new Action(delegate() {
                   StringBuilder sb = new StringBuilder();
                   sb.Append(p.FirstName);
                   sb.Append(" ");
                   sb.Append(p.LastName);
                   string x = sb.ToString();
                }) }
             };
    
             var Watch = new Stopwatch();
             foreach (var t in tests) {
                for (int i = 0; i < 5; i++) {
                   Watch.Reset();
                   long Elapsed = ElapsedTicks(t.Action, Watch, 10000);
                   Console.WriteLine(string.Format("{0}: {1} ticks", t.Name, Elapsed.ToString()));
                }
             }
          }
    
          public static long ElapsedTicks(Action ActionDelg, Stopwatch Watch, int Iterations) {
             Watch.Start();
             for (int i = 0; i < Iterations; i++) {
                ActionDelg();
             }
             Watch.Stop();
             return Watch.ElapsedTicks / Iterations;
          }
       }
