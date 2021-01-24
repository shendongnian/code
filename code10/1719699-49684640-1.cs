    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
    
            myData = new DATA[20]{
            new DATA("Breakfast", 4.00 ,  "Gourment Pancakes"),
            new DATA("Breakfast", 6.00 ,  "Eggs & Toast"),
            new DATA("Breakfast", 7.50 ,  "Oatmeal with OJ"),
            new DATA("Breakfast", 10.75 ,  "Fresh Waffles"),
            new DATA("Breakfast", 11.00 ,  "Bacon Egg & Cheese"),
            new DATA("Breakfast", 4.00 ,  "Bagel & Cream Cheese"),
            new DATA("Breakfast", 4.00 ,  "Butter Potatoes with Toast"),
    
            new DATA("Lunch", 9.50 ,  "Tuna Fish"),
            new DATA("Lunch", 8.00 ,  "Ham & Cheese"),
            new DATA("Lunch", 14.00 ,  "Buffalo Chicken Wrap"),
            new DATA("Lunch", 13.00 ,  "Cheeseburger with Fries"),
            new DATA("Lunch", 6.00 ,  " Jumbo Cheese Pizza"),
            new DATA("Lunch", 9.00,   "Hotdog with Fries"),
            new DATA("Lunch", 9.00,   "Philly Cheese Stake"),
    
            new DATA("Dinner", 22.00,   "Salmon with Two Sides"),
            new DATA("Dinner", 24.00,   "Steak with Two Sides"),
            new DATA("Dinner", 17.00,   "Chicken Parm Dinner"),
            new DATA("Dinner", 25.00,   "Extra Large Lasagna"),
            new DATA("Dinner", 15.00,   "Stuffed Shells"),
            new DATA("Dinner", 16.00,   "Penne Ala Vodka"),  };
            this.DataContext = this;
            passData = new List<DATA>();
        }
    
        public DATA[] myData { get; set; }
    
    
        public List<DATA> passData { get; set; }
    
        public void btnBreakfast_Click(object sender, RoutedEventArgs e)
        {
            //You can have a filter here to filter the data you want to pass to the new page.
            for (int i = 0; i < passData.Count; i++)
            {
                if (myData[i].Distinguisher == "Breakfast")
                {
                    // HomePageListBox.Items.Add(myData[i].description);
                }
            }
    
            Frame.Navigate(typeof(NewPage), passData);
    
        }
    
        private void MainPageListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView list = sender as ListView;
            DATA selected = (DATA)list.SelectedItem;
            passData.Add(selected);
        }
    }
    
    public struct DATA
    {
        public double Price { get; set; }
        public string description { get; set; }
    
        public string Distinguisher { get; set; }
    
        public DATA(string Distinguisher, double Price, string description)
        {
            this.Distinguisher = Distinguisher;
            this.Price = Price;
            this.description = description;
    
        }
    }
