    public class GantChartUserControlViewModel : INotifyPropertyChanged
    {
       // boiler-plate
       public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void OnPropertyChanged(string propertyName)
       {
           PropertyChangedEventHandler handler = PropertyChanged;
           if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
       }
       // Property you want to expose:
       public ObservableCollection<int> MyIntegers
       {
           get {return _myIntegers;}
           set { _myIntegers = value; OnPropertyChanged("MyIntegers"); }
       }
       private ObservableCollection<int> _myIntegers;
    
       // ICommand
       public ICommand TestCommand5 { get; private set;}
       // constructor
       public GantChartUserControlViewModel()
       {
           MyInteger = new ObservableCollection<int>();
           new RelayCommand<object>(ExecuteTestCommand5, CanExecuteTestCommand5);
       }
        public bool CanExecuteTestCommand5(object parameter)
        {
            return true;
        }
        public void ExecuteTestCommand5(object parameter)
        {
            Debug.WriteLine($"\nDataBaseHelperClass: {System.Reflection.MethodBase.GetCurrentMethod()}");
            int testint = (int)parameter;
            CreateTimeLine(testint);
        }
        
        private void CreateTimeLine(int duration)
        {
            MyIntegers.Clear();
            for(int i=0;i<duration;i++)
            {
                MyIntegers.Add(i);
            }
        }      
    }
