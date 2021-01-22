    public sealed class InfoPool : INotifyPropertyChanged
    {
        InfoPool()
        {
        }
        public static InfoPool GetInstance()
        {
            return Nested.instance;
        }
        class Nested
        {
            static Nested()
            {
            }
            internal static readonly InfoPool instance = new InfoPool();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        private String strProp = "default String";
        private Double dblProp = 1.23456;
        public String StrProp
        {
            get { return strProp; }
            set 
            { 
                strProp = value;
                OnPropertyChanged(new PropertyChangedEventArgs("StrProp"));
            }
        }
        
        public Double DblProp
        {
            get { return dblProp; }
            set 
            { 
                dblProp = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DblProp"));
            }
        }
