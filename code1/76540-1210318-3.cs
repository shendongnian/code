    IEnumerable<string> ReadLines()
    {
         string s;
         do
         {
              s = Console.ReadLine();
              yield return s;
         } while (!string.IsNullOrEmpty(s));
    }
    IEnumerable<string> lines = ReadLines();
    lines.Add("foo") // so what is this supposed to do??
