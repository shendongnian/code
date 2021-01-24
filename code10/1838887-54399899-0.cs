    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication98
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                AAPL aapl = new AAPL(FILENAME);
            }
        }
        public class AAPL
        {
            static List<AAPL> aapls = new List<AAPL>();
            private DateTime date { get; set; }
            public decimal open { get; set; }
            public decimal close { get; set; }
            public decimal low { get; set; }
            public decimal high { get; set; }
            public int volume { get; set; }
            public AAPL() { }
            public AAPL(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string line = "";
                AAPL newAAPL = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        if (line.StartsWith("AAPL"))
                        {
                            string dateStr = line.Substring(line.IndexOf(",") + 1);
                            date = DateTime.Parse(dateStr);
                            newAAPL = new AAPL();
                            aapls.Add(newAAPL);
                            newAAPL.date = date;
                        }
                        else
                        {
                            string[] splitArray = line.Split(new char[] { ':' });
                            switch (splitArray[0])
                            {
                                case "Open":
                                    newAAPL.open = decimal.Parse(splitArray[1]);
                                    break;
                                case "Close":
                                    newAAPL.close = decimal.Parse(splitArray[1]);
                                    break;
                                case "Low":
                                    newAAPL.low = decimal.Parse(splitArray[1]);
                                    break;
                                case "High":
                                    newAAPL.high = decimal.Parse(splitArray[1]);
                                    break;
                                case "Volume":
                                    newAAPL.volume = int.Parse(splitArray[1]);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
