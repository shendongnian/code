    public class TestWindow
    {
    private void TestWindow_Loaded(object sender, RoutedEventArgs e)
    {
        RootObject DC = new RootObject();
        DC.QUOTE = new List<QUOTE>();
        for (int I = 1; I <= 10; I++)
        {
            DC.QUOTE.Add(new QUOTE() { name = "Name" + I, symbol = I, SESSION = new List<SESSION>() });
            DC.QUOTE[I - 1].SESSION.Add(new SESSION() { open = "open", high = "100", low = "10", last = "final" });
        }
        grdData.ItemsSource = DC.QUOTE.ToList();
    }
    public class SESSION
    {
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string last { get; set; }
    }
    public class QUOTE
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public List<SESSION> SESSION { get; set; }
    }
    public class RootObject
    {
        public List<QUOTE> QUOTE { get; set; }
    }
    }
