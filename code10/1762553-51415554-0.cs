    XAML:
    <ListView x:Name="lst"                  
            ItemsSource="{Binding Items}"
            CachingStrategy="RecycleElement"
            VerticalOptions="FillAndExpand"
            IsPullToRefreshEnabled="False"
            HasUnevenRows="False">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <Entry Text="{Binding Text}"></Entry>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
    C#:
	public partial class MainPage : ContentPage
	{
        public class Item
        {
            public string Text { get; set; }
        }
        public List<Item> Items { get; set; }
        public MainPage()
		{
			InitializeComponent();  
        }
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Items = new List<Item>();
            for (int i = 0; i < 1000; i++)
            {
                Items.Add(new Item()
                {
                    Text = Guid.NewGuid().ToString()
                });
            }
            lst.ItemsSource = Items;
        }
    }
