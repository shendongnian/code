    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using WpfApp.Annotations;
    
    namespace WpfApp
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : INotifyPropertyChanged
        {
            private bool _isChecked;
    
            public MainWindow()
            {
                InitializeComponent();
    
                Items.Add(new Item {Foo = "Foo1"});
                Items.Add(new Item {Foo = "Foo2"});
                Items.Add(new Item {Foo = "Foo3"});
                Items.Add(new Item {Foo = "Foo4"});
            }
    
            public bool IsChecked
            {
                get => _isChecked;
                set
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
            }
    
            public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class Item
        {
            public string Foo { get; set; }
        }
    }
