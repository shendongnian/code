    namespace TerminalTest
    {
        class Program
        {
            public class TerminalReport
            {
                public string Word { get; set; }
    
                public int Denials { get; set; }
    
                public int Approvals { get; set; }
    
                public int Reversals { get; set; }
    
                public double Amount { get; set; }
    
                public int ON_US { get; set; }
    
                public int Alphalink { get; set; }
    
                public int Interchange { get; set; }
    
                public int Surcharged { get; set; }
    
                public static TerminalReport FromLine(string line)
                {
                    TerminalReport report = new TerminalReport();
                    report.Word = line.Substring(0, 11);
                    line = line.Replace(report.Word, string.Empty).Trim();
                    string[] split = line.Split(' ');
                    int i = 0;
                    // transaction summary
                    report.Denials = int.Parse(split[i++]);
                    report.Approvals = int.Parse(split[i++]);
                    report.Reversals = int.Parse(split[i++]);
                    report.Amount = double.Parse(split[i++]);
                    // billing counts
                    report.ON_US = int.Parse(split[i++]);
                    report.Alphalink = int.Parse(split[i++]);
                    report.Interchange = int.Parse(split[i++]);
                    report.Surcharged = int.Parse(split[i++]);
    
                    return report;
                }
            }
    
            public class TerminalPage
            {
                public int PageNumber { get; set; }
    
                public double TotalSurcharges { get; set; }
    
                public List<TerminalReport> Rows { get; set; }
    
                public TerminalPage(int num)
                {
                    PageNumber = num;
                    Rows = new List<TerminalReport>();
                }
    
                public int TotalDenials
                {
                    get
                    {
                        return rows.Sum(r => r.Denials);
                    }
                }
    
                public int TotalApprovals
                {
                    get
                    {
                        return Rows.Sum(r => r.Approvals;
                    }
                }
    
                public int TotalReversals
                {
                    get
                    {
                        return Rows.Sum(r => r.Reversals;
                    }
                }
    
                public double TotalAmount
                {
                    get
                    {
                        return Rows.Sum(r => r.Amount);
                    }
                }
    
                public int TotalON_US
                {
                    get
                    {
                        return Rows.Sum(r => r.ON_US);
                    }
                }
    
                public int TotalAlphalink
                {
                    get
                    {
                         return Rows.Sum(r => r.Alphalink);
                    }
                }
    
                public int TotalInterchange
                {
                    get
                    {
                         return Rows.Sum(r => r.Interchange);
                    }
                }
    
                public int TotalSurcharged
                {
                    get
                    {
                         return Rows.Sum(r => r.Surcharged);
                    }
                }
            }
    
            private static string CleanString(string text)
            {
                return Regex.Replace(text, @"\s+", " ").Replace(",", string.Empty).Trim();
            }
    
            private static List&lt;TerminalPage&gt; ParseData(string filename)
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    List<TerminalPage> pages = new List<TerminalPage>();
    
                    int pageNumber = 1;
                    TerminalPage page = null;
                    bool parse = false;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        line = CleanString(line);
                        if (line.StartsWith("TRAN TYPE"))
                        {
                            // get rid of the ----- line
                            sr.ReadLine();
    
                            parse = true;
                            if (page != null)
                            {
                                pages.Add(page);
                            }
                            page = new TerminalPage(pageNumber++);
                        }
                        else if (line.StartsWith("="))
                        {
                            parse = false;
                        }
                        else if (line.StartsWith("TOTAL SURCHARGES:"))
                        {
                            line = line.Replace("TOTAL SURCHARGES:", string.Empty).Trim();
                            page.TotalSurcharges = double.Parse(line);
                        }
                        else if (parse)
                        {
                            TerminalReport r = TerminalReport.FromLine(line);
                            page.Rows.Add(r);
                        }
                    }
                    if (page != null)
                    {
                        pages.Add(page);
                    }
    
                    return pages;
                }
            }
    
            static void Main(string[] args)
            {
                string filename = @"C:\bftransactionsp.txt";
                List<TerminalPage> pages = ParseData(filename);
    
                foreach (TerminalPage page in pages)
                {
                    Console.WriteLine("TotalSurcharges: {0}", page.TotalSurcharges);
                    foreach (TerminalReport r in page.Rows)
                            Console.WriteLine(r.Approvals);
                }
            }
        }
    }
