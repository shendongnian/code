    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XNamespace ns = doc.Root.GetDefaultNamespace();
                var historicalData = doc.Descendants(ns + "HistroicalData").Select(x => new
                {
                    operating_mic = (string)x.Element(ns + "operating_mic"),
                    mic = (string)x.Element(ns + "mic"),
                    isin = (string)x.Element(ns + "isin"),
                    feed = (string)x.Element(ns + "feed"),
                    ticker = (string)x.Element(ns + "ticker"),
                    currency = (string)x.Element(ns + "currency"),
                    trades = x.Descendants(ns + "last").Select(y => (decimal)y).ToList()
                }).Select(x => x.trades.Select(trade => new {
                    operatring_mic = x.operating_mic,
                    mic = x.mic,
                    isin = x.isin,
                    feed = x.feed,
                    ticker = x.ticker,
                    currency = x.currency,
                    trade = trade
                })).SelectMany(x => x).ToList();
            }
        }
    }
