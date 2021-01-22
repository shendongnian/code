    public partial class MainWindow : Window
    {
        public static string[] TestProperty
        {
            get
            {
                List<string> result = new List<string>();
                result.Add("red");
                result.Add("green");
                result.Add("blue");
                return result.ToArray();
            }
        }
    
        public MainWindow()
        {
            InitializeComponent();
         ...
