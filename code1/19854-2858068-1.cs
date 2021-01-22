    public class MainViewModel : ViewModelBase
    {
       // most code removed for this example
     
       public MainViewModel()
       {
          GoCommand = new DelegateCommand<object>(OnGoCommand, CanGoCommand);
       }
       
       // flag used by data binding trigger
       private bool _isWorking = false;
       public bool IsWorking
       {
          get { return _isWorking; }
          set
          {
             _isWorking = value;
             OnPropertyChanged("IsWorking");
          }
       }
     
       // button click event gets processed here
       public ICommand GoCommand { get; private set; }
       private void OnGoCommand(object obj)
       {
          if ( _selectedCustomer != null )
          {
             // wait cursor ON
             IsWorking = true;
             _ds = OrdersManager.LoadToDataSet(_selectedCustomer.ID);
             OnPropertyChanged("GridData");
    
             // wait cursor off
             IsWorking = false;
          }
       }
    }
     
