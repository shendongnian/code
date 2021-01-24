    public class AxmModule: NotifierModel
        {
        public static event MyEventHandler ValueChanges;
                public delegate void MyEventHandler(string Value);
             private string _selectedAxmModule ;
                public string SelectedAxmModule 
                {
                    get
                    {
                        return _selectedAxmModule ;
                    }
                    set
                    {
                        _selectedAxmModule = value;
                        if (ValueChanged!= null)
                        {
                            ValueChanged(_selectedAxmModule );
                            RaisePropertyChanged("SelectedAxmModule ");
                        }
                    }
                }
    }
