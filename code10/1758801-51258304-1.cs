    class Employee: ViewModelBase
    {
       private string _status;
       public string Name { get; set; }
       public string Status
       {
         get
         {
            return _status;
         }
         private set
         {
            _status=value;
           RaisePropertyChanged("Status");
         }
       }
    }
