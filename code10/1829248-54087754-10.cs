    namespace App2
    {
        public partial class MainPage : ContentPage
        {
            ObservableCollection<String> employeeList = new ObservableCollection<String>();
            int count = 0;
    
            public MainPage()
            {
                InitializeComponent();
                AddButtion.Clicked += AddButtion_Clicked;
                DelButtion.Clicked += DelButtion_Clicked;
                EmployeeView.ItemsSource = employeeList;
    
                EmployeeView.ItemAppearing += async (object sender, ItemVisibilityEventArgs e) =>
                {
                    if (EmployeeView.IsScrolling) {
                        await DisplayAlert("ItemAppearing", e.Item + " row is appearing", "OK");
                        Console.WriteLine("ItemAppearing!!!!!!!!!!");
                    }
                };
    
            }
                   
            private void AddButtion_Clicked(object sender, EventArgs e)
            {
                employeeList.Add("Mr. Mono"+ count++);
    
                EmployeeView.IsScrolling = false;
            }
    
            private void DelButtion_Clicked(object sender, EventArgs e)
            {
                if (employeeList.Count > 0) {
                    employeeList.RemoveAt(0);
                }
                EmployeeView.IsScrolling = false;
    
            }
        }
    }
