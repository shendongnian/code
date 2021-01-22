    public partial class Window1: Window {
        public Window1() {
            InitializeComponent();
            DataContext = new Coordinator();
        }
    }
    class Coordinator: INotifyPropertyChanged {
        List<Myclass1> list;
        int currId = 0;
        public Myclass1 current {
            get { return list[currId]; }
        }
        public int CurrId {
            get { return currId; }
            set {
                currId = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("current"));
            }
        }
        public Coordinator() {
            list = new List<Myclass1>(){
                new Myclass1(){ Text = "1", o = new Myclass2(){Text="1.1"}},
                new Myclass1(){ Text = "2", o = new Myclass2(){Text="2.2"}},
                new Myclass1(){ Text = "3", o = new Myclass2(){Text="3.3"}}
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    class Myclass1 {
        public string Text { get; set; }
        public Myclass2 o { get; set; }
    }
    class Myclass2 {
        public string Text { get; set; }
    }
