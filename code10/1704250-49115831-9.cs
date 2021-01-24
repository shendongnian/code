    public class GetPropertConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var theCollection = values[0] as ObservableCollection<Tuple<string, string>>;
                return (theCollection?[(int)values[1]])?.Item1; //Item1 is the column name, Item2 is the column's ocmbobox's selectedItem
            }
            catch (Exception)
            {
                //use a better implementation!
                return null;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class DataGridColumnsModel:INotifyPropertyChanged
    {
        private ObservableCollection<string> _dataTypesCollection = new ObservableCollection<string>()
        {
            "Date","String","Number"
        };
        public ObservableCollection<string> DataTypesCollection         
        {
            get { return _dataTypesCollection; }
            set
            {
                if (Equals(value, _dataTypesCollection)) return;
                _dataTypesCollection = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Tuple<string, string>> _headerPropertiesCollection=new ObservableCollection<Tuple<string, string>>()
        {
            new Tuple<string, string>("Column 1", "Date"),
            new Tuple<string, string>("Column 2", "String")
        };   //The Dictionary has a PropertyName (Item1), and a PropertyDataType (Item2)
        public ObservableCollection<Tuple<string,string>> HeaderPropertyCollection
        {
            get { return _headerPropertiesCollection; }
            set
            {
                if (Equals(value, _headerPropertiesCollection)) return;
                _headerPropertiesCollection = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class DataGridModel
    {
        public string FirstProperty { get; set; }   
        public string SecondProperty { get; set; }   
    }
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private RelayCommand _updateItemSourceCommand;
        public RelayCommand UpdateItemSourceCommand
        {
            get
            {
                return _updateItemSourceCommand
                       ?? (_updateItemSourceCommand = new RelayCommand(
                           () =>
                           {
                               //Update your DataGridCollection, you could also pass a parameter and use it.
                               MessageBox.Show("Update has ocured");
                           }));
            }
        }
        private ObservableCollection<DataGridModel> _dataGridCollection=new ObservableCollection<DataGridModel>()
        {
            new DataGridModel(){FirstProperty = "first item",SecondProperty = "second item"},
            new DataGridModel(){FirstProperty = "first item",SecondProperty = "second item"},
            new DataGridModel(){FirstProperty = "first item",SecondProperty = "second item"}
        };
        public ObservableCollection<DataGridModel> DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                if (Equals(value, _dataGridCollection)) return;
                _dataGridCollection = value;
                OnPropertyChanged();
            }
        }
        private DataGridColumnsModel _dataGridColumnsModel=new DataGridColumnsModel();
        public DataGridColumnsModel DataGridColumnsModel
        {
            get { return _dataGridColumnsModel; }
            set
            {
                if (Equals(value, _dataGridColumnsModel)) return;
                _dataGridColumnsModel = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
      
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
