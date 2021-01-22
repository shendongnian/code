    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the multiplier:");
        string stringMult = Console.ReadLine();
        int multiplier;
        Int32.TryParse(stringMult, out multiplier);
        StreamReader sr = new StreamReader(@"C:\Users\[obscured]\Desktop\Fleetops Mod\Data To Process.txt", true);
        string input = sr.ReadToEnd();
        sr.Close();
        StreamWriter sw = new StreamWriter(@"C:\Users\[obscured]\Desktop\Fleetops Mod\Data To Process.txt", false);
        Regex r = new Regex(@"^(\w+)\s*=\s*(\S+)" +
                @"(?:\s+""([^""]+)""\s+(\S+))+",
                RegexOptions.Compiled);
        Match m = r.Match(input);
        if (m.Success) {
            double header = Double.Parse(m.Groups[2].Value);
            sw.WriteLine("{0} = {1}", m.Groups[1].Value,
                             header * multiplier);
            CaptureCollection files = m.Groups[3].Captures;
            CaptureCollection nums  = m.Groups[4].Captures;
            for (int i = 0; i < files.Count; i++) {
                double val = Double.Parse(nums[i].Value);
                sw.WriteLine(@"  ""{0}"" {1}", files[i].Value,
                                    val * multiplier);
            }
        }
        else
            Console.WriteLine("no match");
        sw.Close();
        Console.WriteLine("Done!");
        Console.ReadKey();
    }
