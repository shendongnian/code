    public class CustomerTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template = null;
            if (item != null)
            {
                FrameworkElement element = container as FrameworkElement;
                if (element != null)
                {
                    string templateName = item is ObservableCollection<MyCustomer> ?
                        "MyCustomerTemplate" : "YourCustomerTemplate";
                    template = element.FindResource(templateName) as DataTemplate;
                } 
            }
            return template;
        }
    }
    public class MyCustomer
    {
        public string CustomerName { get; set; }
    }
    public class YourCustomer
    {
        public string CustomerName { get; set; }
    }
    <ResourceDictionary 
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:WpfApplication1"
        >
        <DataTemplate x:Key="MyCustomerTemplate">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="150"/>
                </Grid.RowDefinitions>
                <TextBlock Text="My Customer Template"/>
                <ListBox ItemsSource="{Binding}" DisplayMemberPath="CustomerName" Grid.Row="1"/>
            </Grid>
        </DataTemplate>
        <DataTemplate x:Key="YourCustomerTemplate">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="150"/>
                </Grid.RowDefinitions>
                <TextBlock Text="Your Customer Template"/>
                <ListBox ItemsSource="{Binding}" DisplayMemberPath="CustomerName" Grid.Row="1"/>
            </Grid>
        </DataTemplate>
    </ResourceDictionary>
    <Window 
        x:Class="WpfApplication1.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Window1" 
        Height="300" 
        Width="300"
        xmlns:local="clr-namespace:WpfApplication1"
        >
        <Grid>
            <Grid.Resources>
                <local:CustomerTemplateSelector x:Key="templateSelector"/>
            </Grid.Resources>
            <ContentControl 
                Content="{Binding}" 
                ContentTemplateSelector="{StaticResource templateSelector}" 
                />
        </Grid>
    </Window>
    public partial class Window1
    {
        public Window1()
        {
            InitializeComponent();
            ObservableCollection<MyCustomer> myCustomers = new ObservableCollection<MyCustomer>()
            {
                new MyCustomer(){CustomerName="Paul"},
                new MyCustomer(){CustomerName="John"},
                new MyCustomer(){CustomerName="Mary"}
            };
            ObservableCollection<YourCustomer> yourCustomers = new ObservableCollection<YourCustomer>()
            {
                new YourCustomer(){CustomerName="Peter"},
                new YourCustomer(){CustomerName="Chris"},
                new YourCustomer(){CustomerName="Jan"}
            };
            //DataContext = myCustomers;
            DataContext = yourCustomers;
        }
    }
