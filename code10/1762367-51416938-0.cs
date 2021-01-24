    public class ViewModel
    {
        public ViewModel()
        {
            Example_SelectedIndex = 0; //unnecessary since the default value of an int is 0
        }
        private List<string> _Example_Items = new List<string>()
        {
            "item 1",
            "item 2",
            "item 3"
        };
        public List<string> Example_Items
        {
            get { return _Example_Items; }
            set { _Example_Items = value; }
        }
        private int _Example_SelectedIndex;
        public int Example_SelectedIndex
        {
            get { return _Example_SelectedIndex; }
            set
            {
                if (_Example_SelectedIndex == value)
                    return;
                _Example_SelectedIndex = value;
            }
        }
    }
