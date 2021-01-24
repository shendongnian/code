    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication98
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Element> elements = new List<Element>() {
                    new Element() {  Fachanwendung = "archiMap", Elementtyp = "Herstellerproduktversion", Elementname = "Java SE JRE 8", Date = DateTime.Parse("1/1/2017"), Quantity = 10},
                    new Element() {  Fachanwendung = "archiMap", Elementtyp = "Herstellerproduktversion", Elementname = "Microsoft Window Server 2012 Standard", Date = DateTime.Parse("3/1/2017"), Quantity = 12},
                    new Element() {  Fachanwendung = "Event Management System", Elementtyp = "Herstellerproduktversion", Elementname = "Apache Toimcat 8.0", Date = DateTime.Parse("6/1/2018"), Quantity = 5},
                    new Element() {  Fachanwendung = "Event Management System", Elementtyp = "Herstellerproduktversion", Elementname = "Oracle Java JDK 7", Date = DateTime.Parse("12/1/2018"), Quantity = 5},
                    new Element() {  Fachanwendung = "Event Management System", Elementtyp = "Herstellerproduktversion", Elementname = "Oracle Java JDK 8", Date = DateTime.Parse("1/1/2019"), Quantity = 5}
                };
                Dictionary<string, List<Element>> dict = elements.GroupBy(x => x.Fachanwendung, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                DataTable dt = new DataTable();
                dt.Columns.Add("Fachanwendung", typeof(string));
                dt.Columns.Add("Elementtyp", typeof(string));
                dt.Columns.Add("Elementname", typeof(string));
                //add quarters
                DateTime minDate = elements.Min(x => x.Date);
                DateTime maxDate = elements.Max(x => x.Date);
                DateTime startQuarter = new DateTime(minDate.Year, ((minDate.Month - 1) % 3) + 1, 1);
                DateTime endQuarter = new DateTime(maxDate.Year, ((maxDate.Month - 1) % 3) + 1, 1);
                for (DateTime date = startQuarter; date <= endQuarter; date = date.AddMonths(3))
                {
                    dt.Columns.Add(date.Year.ToString() + " Q" + ((date.Month / 3) + 1).ToString(), typeof(int));
                }
                foreach (KeyValuePair<string, List<Element>> rows in dict)
                {
                    var groups = dict[rows.Key].GroupBy(x => new { Elementtyp = x.Elementtyp, Elementname = x.Elementname, Date = new DateTime(x.Date.Year, ((x.Date.Month - 1) % 3) + 1, 1) }).ToList();
                    foreach (var group in groups)
                    {
                        DataRow newRow = dt.Rows.Add();
                        newRow["Fachanwendung"] = rows.Key;
                        newRow["Elementtyp"] = group.Key.Elementtyp;
                        newRow["Elementname"] = group.Key.Elementname;
                        string quarter = group.Key.Date.Year.ToString() + " Q" + (((group.Key.Date.Month - 1) / 3) + 1).ToString();
                        int total = group.Sum(x => x.Quantity);
                        newRow[quarter] = total;
                    }
                }
            }
        }
        public class Element
        {
            public string Fachanwendung { get; set; }
            public string Elementtyp { get; set; }
            public string Elementname { get; set; }
            public DateTime Date { get; set; }
            public int Quantity { get; set; } 
        }
    }
