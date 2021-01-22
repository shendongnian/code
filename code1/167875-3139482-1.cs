    public partial class Window1 : Window
        {
            protected Dictionary<string, List<int>> lists = new Dictionary<string, List<int>>();
            public Window1()
            {
                InitializeComponent();
                lists["a"] = new List<int>(new int[] {1, 2, 3, 4, 5});
                lists["b"] = new List<int>(new int[] {6, 7, 8, 9});
                lists["c"] = new List<int>(new int[] {1, 2, 3, 4, 5});
    
                XDocument data = new XDocument();
                data.Add(new XElement("rows"));
    
                int maxListLength = lists.Max(l => l.Value.Count);
    
                for (int index = 0; index < maxListLength; ++index )
                {
                    XElement row = new XElement("row");
                    foreach(string k in lists.Keys)
                    {
                        XElement value = new XElement(k);
                        if(index < lists[k].Count)
                        {
                            value.Value = lists[k][index].ToString();
                        }
                        row.Add(value);
                    }
                    data.Root.Add(row);
                }
    
                (Resources["xdp"] as XmlDataProvider).Document = new XmlDocument{InnerXml = data.ToString()};
    
                foreach (string key in lists.Keys)
                {
                    GridViewColumn gvc = new GridViewColumn();
                    gvc.Header = key;
                    gvc.Width = 75;
                    gvc.DisplayMemberBinding = new Binding { XPath = key };
                    gv.Columns.Add(gvc);
                }
            }
        }
