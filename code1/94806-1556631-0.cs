        [XmlRoot(ElementName = "GSP")]
        public class SearchResult
        {
            //public string Title { get; set; }
            [XmlArray(ElementName = "Header")]
            [XmlArrayItem(ElementName = "Title")]
            public List<String> myHeaderItems { get; set; }
            [XmlArray(ElementName = "Results")]
            [XmlArrayItem(ElementName = "Result")]
            public List<ResultItem> mySearchResultItems { get; set; }
            public SearchResult()
            {
                myHeaderItems = new List<String>();
                mySearchResultItems= new List<ResultItem>();
            }
            
            public SearchResult(string title) : this()
            {
                myHeaderItems.Add(title);
            }
        }
        public class ResultItem
        {
            [XmlText]
            public String Flavor;
        }
        
        public void Run()
        {
            SearchResult sr = new SearchResult("Search1");
            sr.mySearchResultItems.Add(new ResultItem() {Flavor = "one" }) ; 
            sr.mySearchResultItems.Add(new ResultItem() {Flavor = "two" }) ; 
            var s1 = new XmlSerializer(typeof(SearchResult));
            Console.WriteLine("Serialized:\n{0}", s1.SerializeToString(sr));
        }
