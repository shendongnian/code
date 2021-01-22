    public class Grouping
    {
        public string Title { get; set; }
        public string Criteria { get; set; }
    }
    XmlDocument xDoc = new XmlDocument();
    var First_Sequence = (from b in XElement.Load("Banners.xml").Elements("BANNER_TEXTS").First().Elements("BANNER_TEXT")
                                  where b.Value != ""
                                  select b);
    var Second_Sequence = (from b in XElement.Load("Banners.xml").Elements("BANNER_TEXTS").Skip(1).First().Elements("BANNER_TEXT")
                                   where b.Value != "Total"
                                   select b).ToList();
    List<Grouping> groups = new List<Grouping>();
    int i = 0;
    foreach (var item in First_Sequence)
    {
        groups.Add(new Grouping { Title = item.Value, Criteria = (Second_Sequence.Skip(i).First().Value).ToString() });
        i++;
    }
