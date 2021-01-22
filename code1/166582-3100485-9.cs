       string[] inputs = {
          "k1=\"v1\" k2=\"v2\" k3=\"v3\" k4=\"v4\"",
          "k1=\"v1\" k2=\"v2\"k3=\"v3\" k4=\"v4\"",
          "    k1=\"v1\"      k2=\"v2\"     k3=\"v3\"     k4=\"v4\"     ",
          "     ",
          " what is this? "
       };
     
       Regex r = new Regex("^\\s*(?:([a-z0-9]+)=\"([a-z0-9]+)\"(?:\\s+|$))+$");
       foreach (string input in inputs) {
         Console.Write(input);
         if (r.IsMatch(input)) {
            Console.WriteLine(": MATCH!");
            Match m = r.Match(input);
            CaptureCollection keys   = m.Groups[1].Captures;
            CaptureCollection values = m.Groups[2].Captures;
            int N = keys.Count;
            for (int i = 0; i < N; i++) {
               Console.WriteLine(i + "[" + keys[i] + "]=>[" + values[i] + "]");
            }
         } else {
            Console.WriteLine(": NO MATCH!");
         }
       }
     
