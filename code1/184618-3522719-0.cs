    public List<Food> PopulateFoodItemListview()
    {
        GetDatabaseConnection();
        string selectFoodItemQuery = @"SELECT food_ItemName, food_UnitPrice FROM t_Food";
        SqlCommand command = new SqlCommand(selectFoodItemQuery, connection);
        SqlDataReader reader = command.ExecuteReader();
        List<Food> foods = new List<Food>();
        List<string> foodList = new List<string>();
        while (reader.Read())
        {
            Food food = new Food();
            food.ItemName = reader.GetString(0);
            MessageBox.Show("ItemName: "+ food.ItemName);
            food.UnitPrice = reader.GetDouble(1);
            MessageBox.Show("UnitPrice: " + food.UnitPrice);
           
        }
        connection.Close();
        return foods;
    }
    public class Food
    {
        private string itemName = "";
        private double unitPrice = 0.0;
        private double itemUnit;
        
        private Customer foodCustomer = new Customer();
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value ; }
        }
        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public double ItemUnit
        {
            get { return itemUnit; }
            set { itemUnit = value; }
        }
        public double GetItemPrice(double itemUnit, double unitPrice)
        {
            double itemPrice = itemUnit*unitPrice;
            return itemPrice;
        }
    }
