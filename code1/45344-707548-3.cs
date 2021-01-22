    using System;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace RangeParser
    {
        class Program
        {
            static void Main(string[] args)
            {
                String input = "1-7,9,16:2:20;1-7; 3:.75 : 10;1,5,9;4-7";
    
                Match sections = (new Regex(@"^((?<section>[^;]+)(;|$))+")).Match(input.Replace(" ", ""));
    
                foreach (Capture section in sections.Groups["section"].Captures)
                {
                    Console.Write("Section ");
    
                    Match subsections = (new Regex(@"^((?<subsection>[^,]+)(,|$))+")).Match(section.Value);
    
                    foreach (Capture subsection in subsections.Groups["subsection"].Captures)
                    {
                        Match subsectionparts = (new Regex(@"^(?<start>[0-9]+)(((:(?<step>[0-9]*\.?[0-9]+):)|-)(?<end>[0-9]+))?$")).Match(subsection.Value);
    
                        if (subsectionparts.Groups["start"].Length > 0)
                        {
                            Decimal start = Decimal.Parse(subsectionparts.Groups["start"].Value, CultureInfo.InvariantCulture);
                            Decimal end = start;
                            Decimal step = 1;
    
                            if (subsectionparts.Groups["end"].Length > 0)
                            {
                                end = Decimal.Parse(subsectionparts.Groups["end"].Value, CultureInfo.InvariantCulture);
    
                                if (subsectionparts.Groups["step"].Length > 0)
                                {
                                    step = Decimal.Parse(subsectionparts.Groups["step"].Value, CultureInfo.InvariantCulture);
                                }
                            }
    
                            Decimal current = start;
    
                            while (current <= end)
                            {
                                Console.Write(String.Format("{0} ", current));
    
                                current += step;
                            }
                        }
                    }
    
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
        }
    }
