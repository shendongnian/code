    class a:INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;       
     
    ....
    private string name;
    public string Name
        {
            get { return name; }
            set
            {
                if (name!=value)
                {
                    name= value;
                    changed();
                }
             }
         }
    private void changed([CallerMemberName]string name=null)
    {
       PropertyChanged.?Invoke(this, new PropertyChangedEventArgs(name));      
    }
    ...
    }
