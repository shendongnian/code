using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace TerminalTest
{
    class Program
    {
        public class TerminalReport
        {
            #region TRANSACTION SUMMARY
            private string word = string.Empty;
            public string Word
            {
                get { return word; }
                set { word = value; }
            }
            private int denials = -1;
            public int Denials
            {
                get { return denials; }
                set { denials = value; }
            }
            private int approvals = -1;
            public int Approvals
            {
                get { return approvals; }
                set { approvals = value; }
            }
            private int reversals = -1;
            public int Reversals
            {
                get { return reversals; }
                set { reversals = value; }
            }
            private double amount = -1;
            public double Amount
            {
                get { return amount; }
                set { amount = value; }
            }
            #endregion
            #region BILLING COUNTS
            private int on_us = -1;
            public int ON_US
            {
                get { return on_us; }
                set { on_us = value; }
            }
            private int alphalink = -1;
            public int Alphalink
            {
                get { return alphalink; }
                set { alphalink = value; }
            }
            private int interchange = -1;
            public int Interchange
            {
                get { return interchange; }
                set { interchange = value; }
            }
            private int surcharged = -1;
            public int Surcharged
            {
                get { return surcharged; }
                set { surcharged = value; }
            }
            #endregion
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
            private int pageNumber = -1;
            public int PageNumber
            {
                get { return pageNumber; }
                private set { pageNumber = value; }
            }
            private double totalSurcharges = -1;
            public double TotalSurcharges
            {
                get { return totalSurcharges; }
                set { totalSurcharges = value; }
            }
            private List&lt;TerminalReport&gt; rows = new List&lt;TerminalReport&gt;();
            public List&lt;TerminalReport&gt; Rows
            {
                get { return rows; }
                set { rows = value; }
            }
            public TerminalPage(int num)
            {
                PageNumber = num;
            }
            public int TotalDenials
            {
                get
                {
                    int total = 0;
                    if (Rows.Count > 0)
                    {
                        foreach (TerminalReport t in rows)
                        {
                            if (t.Denials > 0)
                            {
                                total += t.Denials;
                            }
                        }
                    }
                    return total;
                }
            }
            public int TotalApprovals
            {
                get
                {
                    int total = 0;
                    if (Rows.Count > 0)
                    {
                        foreach (TerminalReport t in rows)
                        {
                            if (t.Approvals > 0)
                            {
                                total += t.Approvals;
                            }
                        }
                    }
                    return total;
                }
            }
            public int TotalReversals
            {
                get
                {
                    int total = 0;
                    if (Rows.Count > 0)
                    {
                        foreach (TerminalReport t in rows)
                        {
                            if (t.Reversals > 0)
                            {
                                total += t.Reversals;
                            }
                        }
                    }
                    return total;
                }
            }
            public double TotalAmount
            {
                get
                {
                    double total = 0;
                    if (Rows.Count > 0)
                    {
                        foreach (TerminalReport t in rows)
                        {
                            if (t.Amount > 0)
                            {
                                total += t.Amount;
                            }
                        }
                    }
                    return total;
                }
            }
            public int TotalON_US
            {
                get
                {
                    int total = 0;
                    if (Rows.Count > 0)
                    {
                        foreach (TerminalReport t in rows)
                        {
                            if (t.ON_US > 0)
                            {
                                total += t.ON_US;
                            }
                        }
                    }
                    return total;
                }
            }
            public int TotalAlphalink
            {
                get
                {
                    int total = 0;
                    if (Rows.Count > 0)
                    {
                        foreach (TerminalReport t in rows)
                        {
                            if (t.Alphalink > 0)
                            {
                                total += t.Alphalink;
                            }
                        }
                    }
                    return total;
                }
            }
            public int TotalInterchange
            {
                get
                {
                    int total = 0;
                    if (Rows.Count > 0)
                    {
                        foreach (TerminalReport t in rows)
                        {
                            if (t.Interchange > 0)
                            {
                                total += t.Interchange;
                            }
                        }
                    }
                    return total;
                }
            }
            public int TotalSurcharged
            {
                get
                {
                    int total = 0;
                    if (Rows.Count > 0)
                    {
                        foreach (TerminalReport t in rows)
                        {
                            if (t.Surcharged > 0)
                            {
                                total += t.Surcharged;
                            }
                        }
                    }
                    return total;
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
                List&lt;TerminalPage&gt; pages = new List&lt;TerminalPage&gt;();
                int pageNumber = 1;
                TerminalPage page = null;
                bool Parse = false;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    line = CleanString(line);
                    if (line.StartsWith("TRAN TYPE"))
                    {
                        // get rid of the ----- line
                        sr.ReadLine();
                        Parse = true;
                        if (page != null)
                        {
                            pages.Add(page);
                        }
                        page = new TerminalPage(pageNumber++);
                    }
                    else if (line.StartsWith("="))
                    {
                        Parse = false;
                    }
                    else if (line.StartsWith("TOTAL SURCHARGES:"))
                    {
                        line = line.Replace("TOTAL SURCHARGES:", string.Empty).Trim();
                        page.TotalSurcharges = double.Parse(line);
                    }
                    else if (Parse)
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
            List&lt;TerminalPage&gt; pages = ParseData(filename);
            foreach (TerminalPage page in pages)
            {
                double TotalSurcharges = page.TotalSurcharges;
                if (page.Rows.Count > 0)
                {
                    foreach (TerminalReport r in page.Rows)
                    {
                        int Approvals = r.Approvals;
                    }
                }
            }
        }
    }
}
