    public class Food
    {
        public string Name { get; set; }
    }
    public class FoodOrder
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
<!---->
    List<Food> foodList; //List of all foods
    BindingList<FoodOrder> foodOrders; //List of orders which is shown in data grid veiw
    private void Form1_Load(object sender, EventArgs e)
    {
        //Load foods, here I created a dummy list of foods
        foodList = Enumerable.Range(1, 3).Select(x => new Food { Name = $"Food {x}" }).ToList();
        //Initialize food orders
        foodOrders = new BindingList<FoodOrder>();
        //Add button for each food
        foodList.ForEach(f =>
        {
            var b = new Button() { Text = f.Name };
            b.Click += (s, ea) =>
            {
                var order = foodOrders.Where(o => o.Name == f.Name).FirstOrDefault();
                //If food already ordered, increase the count, otherwise add to orders
                if (order != null)
                    order.Count++;
                else
                    foodOrders.Add(new FoodOrder { Name = f.Name, Count = 1 });
                //Refresh data grid veiw
                foodOrders.ResetBindings();
            };
            flowLayoutPanel1.Controls.Add(b);
        });
        //Show orders in data grid view
        dataGridView1.DataSource = foodOrders;
    }
