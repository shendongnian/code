    [System.Diagnostics.DebuggerHidden]
    private static void SecretRun(IEnumerable<int> ints)
    {
       foreach (var i in ints)
       {
           try
           {
               if (i < 50) Console.WriteLine("next" + i);
               else throw new Exception("some exception");
           }
           catch
           {
               // Ignored
           }
        }
    }
