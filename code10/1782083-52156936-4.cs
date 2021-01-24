        class FancyDate
        {
            public int Month { get; set; }
            public int Day { get; set; }
            public FancyDate(string fancyDate)
            {
                var split = fancyDate.Split('-');
                Month = Int32.Parse(split[0]);
                Day = Int32.Parse(split[1]);
            }
            public override string ToString()
            {
                return $"{Month:D2}-{Day:D2}";
            }
        }
        class ClientRenewal
        {
            public string ClientName { get; set; }
            public FancyDate RenewalDate { get; set; } 
            public string DomainName { get; set; }
            public class ClientRenewalComparer : IComparer<ClientRenewal>
            {
                public int Compare(ClientRenewal x, ClientRenewal y)
                {
                    if (x != null && y != null)
                        return String.Compare(x.RenewalDate.ToString(), y.RenewalDate.ToString(), StringComparison.Ordinal);
                    throw new ArgumentNullException();
                }
            }
            public ClientRenewal(string clientName, string renewalDate, string domainName)
            {
                this.ClientName = clientName;
                this.RenewalDate = new FancyDate(renewalDate);
                this.DomainName = domainName;
            }
            public override string ToString()
            {
                return $"{DomainName} - {RenewalDate} - {ClientName}";
            }
        }
        class ClientRenewalList
        {
            private List<ClientRenewal> theClientList;
            public ClientRenewalList(List<ClientRenewal> list)
            {
                list.Sort(new ClientRenewal.ClientRenewalComparer());
                theClientList = new List<ClientRenewal>();
                foreach (var item in list)
                {
                    theClientList.Add(item);
                }
            }
            private List<ClientRenewal> RotateListForCurrentDate()
            {
                // Bit of indirection to aid testing
                return RotateListForDate(DateTime.Now);
            }
            public List<ClientRenewal> RotateListForDate(DateTime dateTime)
            {
                var month = dateTime.Month;
                var day = dateTime.Day;
                int i = 0;
                while (i < theClientList.Count)
                {
                    if (theClientList[i].RenewalDate.Month < month)
                    {
                        i++;
                        continue;
                    }
                    if (theClientList[i].RenewalDate.Month == month)
                    {
                        while (theClientList[i].RenewalDate.Day < day)
                        {
                            i++;
                        }
                    }
                    if (theClientList[i].RenewalDate.Month > month) break;
                    if (theClientList[i].RenewalDate.Month >= month && theClientList[i].RenewalDate.Day >= day) break;
                }
                return theClientList.Skip(i).Concat(theClientList.Take(i)).ToList();
            }
            public List<ClientRenewal> GetListForDisplay()
            {
                return RotateListForCurrentDate();
            }
        }
        static void Main(string[] args)
        {
            //mydomain.com     02 - 01           John Doe
            //thisdomain.com   08 - 30           Tim Jones
            //thatdomain.com   10 - 10           Jane Smith
            var listOfClientRenewal = new List<ClientRenewal>()
            {
                new ClientRenewal("John Doe", "02-01", "mydomain.com"),
                new ClientRenewal("Tim Jones", "08-30", "thisdomain.com"),
                new ClientRenewal("Jane Smith", "10-10", "thatdomain.com")
            };
            var list = new ClientRenewalList(listOfClientRenewal).GetListForDisplay();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
