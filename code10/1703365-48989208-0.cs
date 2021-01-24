    public partial class MainWindow : Window
    {    
        public ObservableCollection<Data> DataList { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
    
            ObservableCollection<Person> pList = new ObservableCollection<Person>();
            pList.Add(new Person { Name = "Ma", ID = "1" });
            pList.Add(new Person { Name = "ta", ID = "2" });
            pList.Add(new Person { Name = "ha", ID = "3" });
            pList.Add(new Person { Name = "ri", ID = "4" });
    
            DataList = new ObservableCollection<Data>();
            DataList.Add(new Data { Point = "point1", Code = "code1", PersonList = pList });
            DataList.Add(new Data { Point = "point2", Code = "code2", PersonList = pList });
            DataList.Add(new Data { Point = "point3", Code = "code3", PersonList = pList });
        }
    }
    
    public class Data
    {
        public Data()
        {
            PersonList = new ObservableCollection<Person>();
        }
        public string Point { get; set; }
        public string Code { get; set; }
        public ObservableCollection<Person> PersonList { get; set; }
    }
    
    public class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
