    <Window x:Class="WpfApp1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApp1"
            mc:Ignorable="d"
            Title="MainWindow" Height="450" Width="800"
            DataContext="{Binding RelativeSource={RelativeSource Self}}">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"></RowDefinition>
                <RowDefinition Height="*"></RowDefinition>
            </Grid.RowDefinitions>
            <Button Content="Clear" Click="ButtonBase_OnClick"></Button>
            <DataGrid Grid.Row="1" ItemsSource="{Binding People}" >
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Name" Binding="{Binding Name}"></DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
    </Window>
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using WpfApp1.Annotations;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private ObservableCollection<Person> _people;
    
            public ObservableCollection<Person> People
            {
                get => _people;
                set
                {
                    _people = value;
                    OnPropertyChanged();
                }
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                People = new ObservableCollection<Person>();
    
                People.Add(new Person(){Id = 1, Name = "Jane"});
                People.Add(new Person(){Id = 2, Name = "John"});
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                People.Clear();
            }
        }
    
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
