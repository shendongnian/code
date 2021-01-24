MainWindow.xaml
    <Window x:Class="WpfApp3.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:vm="clr-namespace:WpfApp3.ViewModel"
            mc:Ignorable="d"
            Title="MainWindow" Height="450" Width="800">
        
        <Window.DataContext>
            <vm:MainViewModel />
        </Window.DataContext>
    
        <FlowDocument>
            <Paragraph>
                <Run Text="Sample text"/>
            </Paragraph>
            <Table x:Name="Table1">
            </Table>
        </FlowDocument>
        
    </Window>
MainWindow.xaml.cs
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using WpfApp3.ViewModel;
    
    namespace WpfApp3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainViewModel VM => (MainViewModel) DataContext;
    
            public MainWindow()
            {
                InitializeComponent();
    
                BuildTable();
            }
    
            private void BuildTable()
            {
                foreach (ItemViewModel item in VM.Items)
                {
                    TableRow nameRow = BuildRow(item.Name);
    
                    TableRowGroup group = new TableRowGroup();
                    group.Rows.Add(nameRow);
    
                    Table1.RowGroups.Add(group);
                }
            }
    
            private static TableRow BuildRow(string content)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = content
                };
    
                Block block1 = new BlockUIContainer(textBlock);
    
                TableCell cell = new TableCell();
                cell.Blocks.Add(block1);
    
                TableRow row = new TableRow();
                row.Cells.Add(cell);
    
                return row;
            }
        }
    }
ViewModel->MainViewModel.cs
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace WpfApp3.ViewModel
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            public MainViewModel()
            {
                PopulateData();
            }
    
            private ObservableCollection<ItemViewModel> _Items;
            public ObservableCollection<ItemViewModel> Items
            {
                get => _Items;
                set
                {
                    _Items = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #region Stub
    
            private void PopulateData()
            {
                Items = new ObservableCollection<ItemViewModel>
                {
                    new ItemViewModel
                    {
                        Name = "Item 1",
                    },
                    new ItemViewModel
                    {
                        Name = "Item 2",
                    }
                };
            }
    
            #endregion
        }
    }
ViewModel->ItemViewModel.cs
    namespace WpfApp3.ViewModel
    {
        public class ItemViewModel
        {
            public string Name { get; set; }
        }
    }
