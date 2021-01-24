    public class Constants
    {
        private Dictionary<string, string> testDic;
        public Dictionary<string, string> TestDic
        {
            get { return testDic; }
            set { testDic = value; }
        }
        public Constants()
        {
             TestDic = new Dictionary<string, string>();
    
             TestDic.Add("KEY_Test1", "Test 1");
             TestDic.Add("KEY_Test2", "Test 2");
             TestDic.Add("KEY_Test3", "Test 3");
             TestDic.Add("KEY_Test4", "Test 4");
        }
    }
    public partial class MainWindow : Window
    {
        private Constants myConstants;
        public Constants MyConstants
        {
            get { return myConstants; }
            set { myConstants = value; }
        }
    
        public MainWindow()
        {
            MyConstants = new Constants();
            InitializeComponent();
            DataContext = this;
        }
    }
    <Grid>
        <TextBlock Text="{Binding MyConstants.TestDic[KEY_Test3]}"/>
    </Grid>
