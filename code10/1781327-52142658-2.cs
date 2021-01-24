    using App1.Services;
    
    namespace App1.ViewModels
    {
        public class MainPageViewModel
        {
            private readonly ISpeechDialogService _speechDialogService;
            public MainPageViewModel(ISpeechDialogService speechDialogService)
            {
                _speechDialogService = speechDialogService;
            }
        }
    }
