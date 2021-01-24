    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
        double dPercentage = Convert.ToDouble(((Convert.ToInt32(txtScore1.Text) + Convert.ToInt32(txtScore2.Text) + Convert.ToInt32(txtScore3.Text) + Convert.ToInt32(txtScore4.Text))) / 20.0) * 100;//calculates the percentage
        if(dPercentage >= 90)
        {
            //Percentage is greater than 89
            MessageBox.Show("Eligible For the Gold Award");
        	imgAward.Source = new BitmapImage(new Uri("pack://application:,,,/Images/gold.png", UriKind.Absolute));
        }
        else if(dPercentage >= 75)
        {
    			//(90-75%)
         MessageBox.Show("Eligible For the Silver Award");
        	imgAward.Source = new BitmapImage(new Uri("pack://application:,,,/Images/silver.png", UriKind.Absolute));
        }
        else if (dPercentage >= 60)
        {
    			// (75 - 60%)
         MessageBox.Show("Eligible For the Bronze Award");
        	imgAward.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bronze.png", UriKind.Absolute));
        }else{
    		MessageBox.Show("Not Eligible For the Award");
    		}
    }}
