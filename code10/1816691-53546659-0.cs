     public partial class MainWindow : Window
    {
        List<System.Windows.Controls.TextBlock> randomBoxList = new List<System.Windows.Controls.TextBlock>();
        public MainWindow()
        {
            InitializeComponent();
            randomBoxList.Add(randomBoxOne);
            randomBoxList.Add(randomBoxTwo);
            randomBoxList.Add(randomBoxThree);
            randomBoxList.Add(randomBoxFour);
            randomBoxList.Add(randomBoxFive);
        }
        Random randomGenerator = new Random();
        int randomNumber;
        private void randomButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (System.Windows.Controls.TextBlock textBlock in randomBoxList)
            {
                randomNumber = randomGenerator.Next(1, 7);
                textBlock.Text = randomNumber.ToString();
            }
        }
    }
