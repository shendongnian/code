    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication62
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants("response").FirstOrDefault().Elements("alipay").Select(x => new
                {
                    alipay_trans_id = (string)x.Element("alipay_trans_id"),
                    partner_trans_id = (string)x.Element("partner_trans_id"),
                    alipay_buyer_login_id = (string)x.Element("alipay_buyer_login_id"),
                    alipay_buyer_user_id = (string)x.Element("alipay_buyer_user_id"),
                    alipay_pay_time = (string)x.Element("alipay_pay_time"),
                    exchange_rate = (decimal)x.Element("exchange_rate"),
                    trans_amount = (decimal)x.Element("trans_amount"),
                    trans_amopunt_CNY = (decimal)x.Element("alipay_trans_id"),
                    result_code = (string)x.Element("result_code")
                }).FirstOrDefault();
            }
        }
    }
