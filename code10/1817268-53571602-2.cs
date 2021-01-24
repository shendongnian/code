        /*Xaml Code*/
         <Page
        x:Class="App1.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App1"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    
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
    </Page>    
    //C# code
    namespace App1
    {
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
    }
