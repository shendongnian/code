    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace LogParser
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int counterLine = 0;
            int counterTimeout = 0;
            string line = String.Empty;
            string previousLine = String.Empty;
            DateTime previousDt = DateTime.MaxValue;
            Regex regex = new Regex(@"\d{2}:\d{2}:\d{2}\.\d{4}");
            try
            {
                System.IO.StreamReader file = new 
     System.IO.StreamReader(args[0]);
                Console.WriteLine("Profesionalno branje logov se začenja:\n");
                StreamWriter writer = new 
     StreamWriter("C:\\Users\\Jan\\Desktop\\log.txt", true);
                while ((line = file.ReadLine()) != null)
                {
                    counterLine++;
                    foreach (Match m in regex.Matches(line))
                    {
                        DateTime dt = new DateTime();
                        if (DateTime.TryParseExact(m.Value, "HH:mm:ss.ffff", null, DateTimeStyles.None, out dt))
                        {
                            if ((dt - previousDt).TotalSeconds > 1)
                            {
                                counterTimeout++;
                                Console.WriteLine(previousLine);
                                Console.WriteLine(line);
                                writer.WriteLine(previousLine);
                                writer.WriteLine(line);
                            }
                            previousLine = line;
                            previousDt = dt;
                        }
                    }
                }
                file.Close();
                writer.Close();
                Console.WriteLine("\nBranje logov je končano. Prebrali smo: {0} vrstic ter izpisali " +
                                  "{1} vrstic, kjer je bil timeout v datoteko.", counterLine, counterTimeout);
            }
            catch (Exception e)
            {
                Console.OpenStandardError();
                Console.WriteLine(e.Message);
            }
            if (args.Length < 1)
            {
                Console.OpenStandardError();
                Console.WriteLine("Uporaba: {0} LOG_FILE", AppDomain.CurrentDomain.FriendlyName);
                Console.ReadKey();
                return;
            }
        }
    }
    }
