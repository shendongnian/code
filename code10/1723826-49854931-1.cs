    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Report report =  new Report(FILENAME);
                report.Print();
                Console.ReadLine();
            }
        }
        public class Report
        {
            public static List<Report> reports = new List<Report>();
            public static int numberClosed { get; set; }
            public static int defects { get; set; }
            public static decimal points { get; set; }
            public string quarter { get; set; }
            public string release { get; set; }
            public int numberFeatures { get; set; }
            public int worked { get; set; }
            public int completed { get; set; }
            string patternWith = @"With the ongoing of \((?'quarter'[^\)]+)\) release \((?'release'[^\)]+)\)";
            string patternFeature = "features";
            string patternClose = "Team was able to close";
            string patternNumbers = @"\d+(.\d+)?";
            Match match = null;
            MatchCollection matches = null;
            public Report() { }
            public Report(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                Report report = null;
                string inputLine = "";
                while((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if(inputLine.Length > 0)
                    {
                        match = Regex.Match(inputLine, patternWith);
                        if(match.Success)
                        {
                                report = new Report();
                                reports.Add(report);
                                report.quarter = match.Groups["quarter"].Value;
                                report.release = match.Groups["release"].Value;
                                continue;
                        }
                        match = Regex.Match(inputLine, patternFeature);
                        if (match.Success)
                        {
                            matches = Regex.Matches(inputLine, patternNumbers);
                            report.numberFeatures = int.Parse(matches[0].Value);
                            report.worked = int.Parse(matches[1].Value); 
                            report.completed  = int.Parse(matches[2].Value);
                            continue;
                        }
                        match = Regex.Match(inputLine, patternClose);
                        if (match.Success)
                        {
                            matches = Regex.Matches(inputLine, patternNumbers);
                            Report.numberClosed  = int.Parse(matches[0].Value);
                            Report.defects = int.Parse(matches[1].Value);
                            Report.points  = decimal.Parse(matches[2].Value);
     
     
                            break;
                        }
                    }
                }
                reader.Close();
            }
            public void Print()
            {
                Console.WriteLine("Summary : Reports = '{0}',  Closed = '{1}', Defects = '{2}', Points = '{3}'",
                    Report.reports.Count,
                    Report.numberClosed,
                    Report.defects,
                    Report.points);
                foreach (Report report in Report.reports)
                {
                    Console.WriteLine("Quarter : '{0}', Release : '{1}', Features : '{2}', Worked : '{3}', Completed : '{4}'",
                        report.quarter,
                        report.release,
                        report.numberFeatures,
                        report.worked,
                        report.completed);
                }
            }
     
        }
    }
