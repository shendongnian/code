    class ViewModel
    {
        public MyModel SelectedModel { get; set; }
        public ICommand MyCommand => new DelegateCommand(MyCommandMethod);
        public void MyCommandMethod()
        {
            string representation = SelectedModel.Representation;
        }
    }
