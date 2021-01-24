    public partial class MainWindow : Window
    {
        List<KeyValuePair<string, int>> tracking = new List<KeyValuePair<string, int>>();
        public MainWindow()
        {
            InitializeComponent();
            Hashtable numbers = new Hashtable();
            numbers.Add("010", 0.10m);
            numbers.Add("020", 0.20m);
            numbers.Add("030", 0.30m);
            numbers.Add("040", 0.40m);
            numbers.Add("050", 0.50m);
            List<decimal> items = new List<decimal>();
            items.Add(Convert.ToDecimal(numbers["010"]));
            items.Add(Convert.ToDecimal(numbers["020"]));
            items.Add(Convert.ToDecimal(numbers["030"]));
            items.Add(Convert.ToDecimal(numbers["040"]));
            items.Add(Convert.ToDecimal(numbers["050"]));
            lbTodoList.ItemsSource = items;
        }
        private void lbTodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = this.lbTodoList.SelectedItem.ToString();
            if (!tracking.Select(x => x.Key == item).Any())
            {
                tracking.Add(new KeyValuePair<string, int>(item, 1));
                Console.WriteLine(item + " has been selected once");
            }
            else
            {
                var currentItem = tracking.SingleOrDefault(x => x.Key == item);
                var value = currentItem.Value;
                tracking.Remove(currentItem);
                value++;
                tracking.Add(new KeyValuePair<string, int>(item, value));
                Console.Clear();
                Console.WriteLine(item + " has been selected " + value + " times");
            }
        }
    }
