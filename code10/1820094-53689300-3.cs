    public sealed partial class MainPage : Page
        {
           
            List<Car> cars = new List<Car>();
            public MainPage()
            {
                cars.Add(new Car() { imgCar = "ms-appx:///Assets/1.jpg", name = "Car1", price = "10000" });
                cars.Add(new Car() { imgCar = "ms-appx:///Assets/2.jpg", name = "Car2", price = "10001" });
                cars.Add(new Car() { imgCar = "ms-appx:///Assets/3.jpg", name = "Car3", price = "10002" });
                this.InitializeComponent();    
                
            }
            private void Add_Click(object sender, RoutedEventArgs e)
            {
                List<Car> mySelectedItems = new List<Car>();
                foreach (Car item in listCars.SelectedItems)
                {
                    mySelectedItems.Add(item);
                }
                Frame.Navigate(typeof(Page2), mySelectedItems);
            }
        }
        public class Car
        {
            public string imgCar { get; set; }
            public string name { get; set; }
            public string price { get; set; }
        }    
