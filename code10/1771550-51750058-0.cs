    public class MyViewModel : BaseViewModel
    {
        private MyObject _myObject;
        public MyObject MyObject 
        { 
           get { return _myObject; }
           private set { _myObject = value; NotifyModelChange(); }
        }
    
        public string IdMvvm
        {
            set
            {
                if (this.MyObject.Id != value)
                {
                    MyObject.Id = value;
                    OnPropertyChanged(nameof(IdMvvm));
                }
            }
            get { return MyObject.Id; }
        }
    
        public string NameMvvm
        {
            set
            {
                if (this.MyObject.Name != value)
                {
                    MyObject.Name = value;
                    OnPropertyChanged(nameof(NameMvvm));
                }
            }
            get { return MyObject.Name; }
        }
       
        private void NotifyModelChange()
        {
             OnPropertyChanged(nameof(IdMvvm));
             OnPropertyChanged(nameof(NameMvvm));
        }
    }
