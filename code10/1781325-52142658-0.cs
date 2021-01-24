    public class ViewModelLocator
    {
        public MainPageViewModel MainPageViewModel
        {
            get
            {
                ISpeechDialogService dialogService = new SpeechDialogService();
                MainPageViewModel vm = new MainPageViewModel(dialogService);
                return vm;
            }
        }
    }
