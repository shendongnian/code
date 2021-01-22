    using System;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace GerneralTestApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                String input = "1-7,9,16:2:20;1-7;3:.25:10;1,5,9;4-7";
    
                Match sections = (new Regex(@"^((?<section>[^;]+)(;|$))+")).Match(input);
    
                foreach (Capture section in sections.Groups["section"].Captures)
                {
                    Console.WriteLine("New Section");
                    Console.WriteLine("===========");
                    Console.WriteLine();
    
                    Match subsections = (new Regex(@"^((?<subsection>[^,]+)(,|$))+")).Match(section.Value);
    
                    foreach (Capture subsection in subsections.Groups["subsection"].Captures)
                    {
                        Match subsectiontype = (new Regex(@"(?<value>^[0-9]+$)|(?<range>^[0-9]+-[0-9]+$)|(?<rangewithstep>^[0-9]+:\.?[0-9]+:[0-9]+$)")).Match(subsection.Value);
    
                        Decimal start = 0;
                        Decimal end = -1; // This skipps any output if no match is found.
                        Decimal step = 1;
    
                        if (subsectiontype.Groups["value"].Length > 0)
                        {
                            start = Decimal.Parse(subsectiontype.Groups["value"].Value, CultureInfo.InvariantCulture);
                            end = start;
                            step = 1;
                        }
                        else if (subsectiontype.Groups["range"].Length > 0)
                        {
                            Match range = (new Regex(@"^(?<start>[0-9]+)-(?<end>[0-9]+)")).Match(subsectiontype.Value);
    
                            start = Decimal.Parse(range.Groups["start"].Value, CultureInfo.InvariantCulture);
                            end = Decimal.Parse(range.Groups["end"].Value, CultureInfo.InvariantCulture);
                            step = 1;
                        }
                        else if (subsectiontype.Groups["rangewithstep"].Length > 0)
                        {
                            Match rangewithstep = (new Regex(@"^(?<start>[0-9]+)\:(?<step>\.?[0-9]+)\:(?<end>[0-9]+)$")).Match(subsectiontype.Value);
    
                            start = Decimal.Parse(rangewithstep.Groups["start"].Value, CultureInfo.InvariantCulture);
                            end = Decimal.Parse(rangewithstep.Groups["end"].Value, CultureInfo.InvariantCulture);
                            step = Decimal.Parse(rangewithstep.Groups["step"].Value, CultureInfo.InvariantCulture);
                        }
    
                        Decimal current = start;
    
                        while (current <= end)
                        {
                            Console.Write(String.Format("{0} ", current));
    
                            current += step;
                        }
                    }
    
                    Console.WriteLine();
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
        }
    }
