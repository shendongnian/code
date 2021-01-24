    public class YourViewModel : BaseViewModel
    {
        public ICommand Button1Command { get; set; }
        private bool _enableButton2;
        public bool EnableButton2
        {
            get
            {
                return _enableButton2;
            }
            set
            {
                _enableButton2= value;
                RaisePropertyChanged();
            }
        }
        public YourViewModel()
        {
             Button1Command =new Command(Button1Clicked);
        }
        private void Button1Clicked()
        {
            EnableButton2=true;    //Whenever you need to enable or disable set it true/false
        }
    }
