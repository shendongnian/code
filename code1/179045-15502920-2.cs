    public class myClass
    {
        private SolidColorBrush _mySelectedItem = new SolidColorBrush();
        public SolidColorBrush mySelectedItem
        {
            get { return _mySelectedItem; }
            set { _mySelectedItem = value; }
        }
    
        public int mySelectedIndex
        {
            get { return 4; }
        }
    }
