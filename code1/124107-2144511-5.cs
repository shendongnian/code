    public class TestColors
    {
        public TestColors()
        {
            Colors = new ObservableCollection<string>();
            Colors.Add("red");
            Colors.Add("blue");
            Colors.Add("green");
        }
    
        public ObservableCollection<string> Colors { get; set; }
    }
