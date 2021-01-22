    public class MyViewModel : ITextBoxController
    {
        public MyViewModel()
        {
            Value = "My Text";
            SelectAllCommand = new RelayCommand(p =>
            {
                if (SelectAll != null)
                    SelectAll(this);
            });
        }
    
        public string Value { get; set; }
        public RelayCommand SelectAllCommand { get; private set; }
    
        public event SelectAllEventHandler SelectAll;
    }
