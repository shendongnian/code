    public class ViewModelLocator
    {
        private static readonly MainViewModel mainViewModel;
        static ViewModelLocator()
        {
            mainViewModel = new MainViewModel();
        }
        public static MainViewModel MainViewModel => mainViewModel;
    }
