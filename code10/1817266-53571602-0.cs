    /*Xaml Code*/
     <Grid>
        <ListView ItemsSource="{x:Bind items,Mode=OneWay}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:Item">
                    <StackPanel Orientation="Horizontal">
                        <CheckBox IsChecked="{x:Bind is_checked}"></CheckBox>
                        <TextBlock Text="{x:Bind text}"></TextBlock>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
    //C# code
     public sealed partial class MainPage : Page
        {
            ObservableCollection<Item> items;
            public MainPage()
            {
                items = new ObservableCollection<Item>();
                items.Add(new Item() { is_checked = true, text = "item1" });
                items.Add(new Item() { is_checked = true, text = "item2" });
                items.Add(new Item() { is_checked = false, text = "item3" });
                this.InitializeComponent();
            } 
           
        }
        public class Item
        {
          public   bool is_checked { get; set; }
          public  string text { get; set; }
        }
