    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
             double dPercentage = Convert.ToDouble(((Convert.ToInt32(txtScore1.Text) + Convert.ToInt32(txtScore2.Text) + Convert.ToInt32(txtScore3.Text) + Convert.ToInt32(txtScore4.Text)) * 20) / 100);//calculates the percentage
        if(dPercentage >= 90)
        {
            //Percentage is greater than 89
            MessageBox.Show("Eligible For the Gold Award");
        	imgAward.Source = new BitmapImage(new Uri(@"Images/gold.png", UriKind.RelativeOrAbsolute));
        }
        else if(dPercentage >= 75)
        {
    			//(90-75%)
         MessageBox.Show("Eligible For the Silver Award");
        	imgAward.Source = new BitmapImage(new Uri(@"Images/silver.png", UriKind.RelativeOrAbsolute));
        }
        else if (dPercentage >= 60)
        {
    			// (75 - 60%)
         MessageBox.Show("Eligible For the Bronze Award");
       		imgAward.Source = new BitmapImage(new Uri(@"Images/bronze.png", UriKind.RelativeOrAbsolute));
        }else{
    		MessageBox.Show("Not Eligible For the Award");
    		}
    }}
