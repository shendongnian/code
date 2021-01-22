    Stopwatch sw = new Stopwatch (); sw.Start (); sw.Stop (); sw.Reset ();
    double sum = 0;
    int n = 1000;
    Console.WriteLine ("\nGetName method way:");
    for (int i = 0; i < n; i++) {
       sw.Start ();
       string t = Enum.GetName (typeof (Roles), roleValue);
       sw.Stop ();
       sum += sw.Elapsed.TotalMilliseconds;
       sw.Reset ();
    }
    Console.WriteLine ($"Average of {n} runs using Getname method casting way: {sum / n}");
    Console.WriteLine ("\nExplicit casting way:");
    for (int i = 0; i < n; i++) {
       sw.Start ();
       string t = ((Roles)roleValue).ToString ();
       sw.Stop ();
       sum += sw.Elapsed.TotalMilliseconds;
       sw.Reset ();
    }
    Console.WriteLine ($"Average of {n} runs using Explicit casting way: {sum / n}");
