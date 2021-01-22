        static void Main(string[] args)
        {
            Debug.WriteLine(DateTime.Now.ToString() + " entering main");
            // USED THIS DOS COMMAND TO GET ALL THE DAILY FILES INTO A SINGLE FILE: copy *.log target.log 
            string[] lines = File.ReadAllLines(@"C:\Log File Analysis\12-8 E5.log");
            Debug.WriteLine(lines.Count().ToString());
            string[] a = lines.Where(x => !x.StartsWith("#Software:") &&
                                          !x.StartsWith("#Version:") &&
                                          !x.StartsWith("#Date:") &&
                                          !x.StartsWith("#Fields:") &&
                                          !x.Contains("_vti_") &&
                                          !x.Contains("/c$") &&
                                          !x.Contains("/favicon.ico") &&
                                          !x.Contains("/ - 80")
                                     ).ToArray();
            Debug.WriteLine(a.Count().ToString());
            string[] b = a
                        .Select(l => l.Split(' '))
                        .Select(words => string.Join(",", words))
                        .ToArray()
                        ;
            System.IO.File.WriteAllLines(@"C:\Log File Analysis\12-8 E5.csv", b);
            Debug.WriteLine(DateTime.Now.ToString() + " leaving main");
        }
