    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = new List<string>
            {
                "FirstName,LastName,Title,BirthDate,HireDate,City,Region",
                "Nancy,Davolio,Sales Representative,1948-12-08,1992-05-01,Seattle,WA",
                "Andrew,Fuller,Vice President Sales,1952-02-19,1992-08-14,Tacoma,WA",
                "Janet,Leverling,Sales Representative,1963-08-30,1992-04-01,Kirkland,WA",
                "Margaret,Peacock,Sales Representative,1937-09-19,1993-05-03,Redmond,WA",
                "Steven,Buchanan,Sales Manager,1955-03-04,1993-10-17,London,NULL",
                "Michael,Suyama,Sales Representative,1963-07-02,1993-10-17,London,NULL",
                "Robert,King,Sales Representative,1960-05-29,1994-01-02,London,NULL",
                "Laura,Callahan,Inside Sales Coordinator,1958-01-09,1994-03-05,Seattle,WA",
                "Anne,Dodsworth,Sales Representative,1966-01-27,1994-11-15,London,NULL"
            };
            List<int> widths = new List<int> { 12, 22, 32, 13, 12, 17, 8 };
            List<string> outputs = inputs.Select(s => ToFixedWidths(s, ',', widths)).ToList();
            outputs.ForEach(s => System.Diagnostics.Debug.WriteLine(s));
            Console.ReadLine();
        }
        private static string ToFixedWidths(string s, char separator, List<int> widths)
        {
            List<string> split = s.Split(separator).ToList();
            return string.Join(String.Empty, split.Select((ss, i) => ss.PadRight(widths[i], ' ')).ToArray());
        }
    }
