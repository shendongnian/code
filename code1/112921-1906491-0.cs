    public class MyViewModel : BaseViewModel
    {
        public int Result
        {
            get { return _result; }
            set
            {
                _result = value; 
                this.RaisePropertyChanged("Result");
            }
        }
    }
