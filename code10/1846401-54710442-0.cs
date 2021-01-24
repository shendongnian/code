    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication100
    {
        class Program
        {
    		static void Main(string[] args)
    		{
                List<string> IdsList = new List<string>() {
                                     "A-28.03.18-B",
                                     "S-17.05.18-G", 
                                     "L-17.05.18-P",
                                     "M-28.03.18-T",
                                     "B-17.05.18-U"
                                  };
                List<string> ShippingNumbersList = new List<string>() {
                                                  "100,200,300", 
                                                  "100,900", 
                                                  "200,300,100",
                                                  "100,900,300",
                                                  "100,300"
                                              };
                var results = Shipping.MergeList(IdsList, ShippingNumbersList);
            }
     
        }
        public class Shipping
        {
            public static object MergeList(List<string> ids, List<string> numbers)
            {
                string pattern = @"\w-(?'day'[^\.]+)\.(?'month'[^\.]+)\.(?'year'[^-]+)";
                List<KeyValuePair<DateTime, string>> idDates = new List<KeyValuePair<DateTime,string>>();
                foreach(string id in ids)
                {
                    Match match = Regex.Match(id,pattern);
                    idDates.Add(new KeyValuePair<DateTime, string>( new DateTime(2000 + int.Parse(match.Groups["year"].Value), int.Parse(match.Groups["month"].Value), int.Parse(match.Groups["day"].Value)), id));
                }
                var groups = idDates.SelectMany((x, i) => numbers[i].Split(new char[] {','}).Select(y => new { idDate = x, number = y })).ToList();
                var groupDates = groups.GroupBy(x => new { date = x.idDate.Key, number = x.number }).ToList();
                var results = groupDates.Select(x => new { number = x.Key.number, ids = x.Select(y => y.idDate.Value).ToList() }).ToList();
                return results;
            }
        }
    }
