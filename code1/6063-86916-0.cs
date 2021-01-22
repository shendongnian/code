      using (TextWriter w = File.CreateText("log.txt")) {
         w.WriteLine("This is line one");
         w.WriteLine("This is line two");
      }
      using (TextReader r = File.OpenText("log.txt")) {
         string s;
         while ((s = r.ReadLine()) != null) {
            Console.WriteLine(s);
         }
      }
