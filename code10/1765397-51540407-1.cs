    public class MyDataObject
    {
        public MyDataObject()
        {
            ClickCommand = new Command(AccessOtherData);
        }
        public ICommand ClickCommand { get; }
        // Other data properties and such
        private void AccessOtherData()
        {
            // Todo
        }
    }
