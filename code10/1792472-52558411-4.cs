    public class MainWindowVM
    {
        private string m_OneTwoThree;
        public string OneTwoThree{
            get { return OneTwoThree; }
            set {
                if (m_OneTwoThree != value){
                    m_OneTwoThree = value;
                    NotifyPropertyChanged(nameof(OneTwoThree)); //if you need this let me know
                }
            }
        }       
        public MainWindowVM()
        {
            
        }
        public ICommand RandomCommand { get { return new RelayCommand(OnRandom, IsOneTwoThree); } }
        private void OnRandom()
        {
            //do stuff
        }
        private bool IsOneTwoThree(){
            if (OneTwoThree == "123"){
                return true;
            }
            return false;
        }
    }
