     namespace SilverlightApplication
     {
      public partial class MainPage : UserControl
     {
        public MainPage()
        {
            InitializeComponent();
            loadLists();
        }
        private void loadLists()
        {
            ObservableCollection<Temp2> tColl = new ObservableCollection<Temp2>();            
            Temp1 t1 = new Temp1();
            t1.Text1 = "DataContext1";
            t1.Text2 = "DataContext2";            
            tColl.Add(new Temp2() { Image = "", Data = "Item1" });
            tColl.Add(new Temp2() { Image = "", Data = "Item2" });
            DataContextStack.DataContext = t1;
            lst2.ItemsSource = tColl;            
        }
    }
    public class Temp1
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        
    }
    public class Temp2
    {
        public string Image { get; set; }
        public string Data { get; set; }
    }
    }
