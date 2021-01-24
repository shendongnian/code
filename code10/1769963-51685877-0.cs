    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                SortedUser sortedUser = new SortedUser();
                sortedUser.Output(FILENAME);
            }
        }
        public class SortedUser
        {
            public string Email { get; set; }
            public List<IpInfo> IPAndCountries = new List<IpInfo>();
            public void Output(string filename)
            {
                StreamWriter writer = new StreamWriter(filename);
                string line = "";
                line = string.Join(",",new string[] {"Email","Ip","Hostname", "City", "Region", "Country", "Loc", "Org", "Postal"});
                writer.WriteLine(line);
                foreach (IpInfo ipInfo in IPAndCountries)
                {
                    line = string.Join(",",
                        Email,
                        ipInfo.Ip,
                        ipInfo.Hostname,
                        ipInfo.City,
                        ipInfo.Region,
                        ipInfo.Country,
                        ipInfo.Loc,
                        ipInfo.Org,
                        ipInfo.Postal
                    );
                    writer.WriteLine(line);
                }
                writer.Flush();
                writer.Close();
            }
        }
     public class IpInfo
        {
            public string Ip { get; set; }
            public string Hostname { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string Country { get; set; }
            public string Loc { get; set; }
            public string Org { get; set; }
            public string Postal { get; set; }
            writer.WriteLine(line);
        }
    }
