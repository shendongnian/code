    public class TempVM : BaseViewModel
    {
        private int _intP;
        public int IntP
        {
            get { return _intP; }
            set { Set<int>(ref _intP, value); }
        }
    }
