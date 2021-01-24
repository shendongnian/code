        public class ViewModelLocator
    {
        	 private MainWindowViewModel mainWindowViewModel;
	  public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                if (mainWindowViewModel == null)
                    mainWindowViewModel = new MainWindowViewModel();
                return mainWindowViewModel;
            }
        }
        private DataFactoryViewModel dataFactoryViewModel;
	 public DataFactoryViewModel DataFactoryViewModel
        {
            get
            {
                if (dataFactoryViewModel == null)
                    dataFactoryViewModel = new DataFactoryViewModel();
                return dataFactoryViewModel;
            }
        }
    }
