    class MainWindowViewModel
    {
        public IVMOne VMOne { get; set; }
        public MainWindowViewModel(IVMOne vmOne)
        {
            VMOne = vmOne;
        }
    }
