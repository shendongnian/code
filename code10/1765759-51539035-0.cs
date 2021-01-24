        public class ViewModelLocator
    {
        private DependencyObject dummy = new DependencyObject();
    
        public IMainViewModel MainViewModel
        {
            get
            {
                if (IsInDesignMode())
                {
                    return new MockMainViewModel();
                }
    
                return MyIoC.Container.GetExportedValue<IMainViewModel>();
            }
        }
    
        // returns true if editing .xaml file in VS for example
        private bool IsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(dummy);
        }
    }
