     private Action[] _functions;
     public void MainEntryPoint()
     {
         _functions = new Action[] { StartTrialWithFixedValue1, StartTrialWithFixedValue2, StartTrialWithRandomValue };
         List<int> trialMarkers = new List<int>() { 1, 1, 2, 2, 3 };
         DoThings(trialMarkers);
     }
     public void DoThings(IEnumerable<int> indexesOfFuctions)
     {
         foreach (var index in indexesOfFuctions)
         {
             _functions[index-1]();
         }
     }
     private void StartTrialWithFixedValue1()
     {
         Trace.WriteLine("StartTrialWithFixedValue1");
     }
     private void StartTrialWithFixedValue2()
     {
         Trace.WriteLine("StartTrialWithFixedValue2");
     }
     private void StartTrialWithRandomValue()
     {
         Trace.WriteLine("StartTrialWithRandomValue");
     }
