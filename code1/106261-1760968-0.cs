    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition />
                <RowDefinition />
                <RowDefinition />
            </Grid.RowDefinitions>
            <ListBox x:Name="list" 
                     ItemsSource="{Binding}"
                     DisplayMemberPath="Name"/>
            <TextBox Text="{Binding ElementName=list, Path=SelectedItem.Name}"
                     Grid.Row="1"/>
            <TextBox Text="{Binding ElementName=list, Path=SelectedItem.Val}"
                     Grid.Row="2" />
        </Grid>
    </Window>
    namespace WpfApplication1 {
        public class Thing : INotifyPropertyChanged {
            private string _name;
            private double _val;
    
            public string Name {
                get { return _name; }
                set {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
    
            public double Val {
                get { return _val; }
                set {
                    _val = value;
                    OnPropertyChanged("Val");
                }
            }
    
            protected void OnPropertyChanged(string propertyName) {
                PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
                if (propertyChanged != null) {
                    propertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();
    
                DataContext = new List<Thing> { new Thing { Name = "A", Val = 1.0 }, new Thing { Name = "B", Val = 2.0 } };
            }
        }
    }
