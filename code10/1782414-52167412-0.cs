        using System.Text.RegularExpressions;
        public class Record
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string Date { get; set; }
            public string Job { get; set; }
        }
        public List<Record> Test()
        {
            string s = @"User name : John
            ID : 221223
            Date : 23.02.2018
            Job: job1
            User name : Andrew
            ID : 378292
            Date : 12.08.2017
            Job: job2
            User name : Chris
            ID: 930712
            Date : 05.11.2016
            Job: job3
            ";
            Regex r = new Regex(@"User\sname\s:\s(?<name>\w+).*?ID\s:\s(?<id>\w+).*?Date\s:\s(?<date>[0-9.]+).*?Job:\s(?<job>\w\w+)",RegexOptions.Singleline);
            r.Matches(s);
            return (from Match m in r.Matches(s)
                     select new Record
                     {
                         Name = m.Groups["name"].Value,
                         ID = m.Groups["id"].Value,
                         Date = m.Groups["date"].Value,
                         Job = m.Groups["job"].Value
                     }).ToList();
        }
