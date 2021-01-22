    public class MainWindowViewModel : ViewModel
    {
        [RaisePropertyChanged]
        public string Message { get; set; }
    
        [RaisePropertyChanged]
        [SetsHasChanged]
        public string DataThatCausesModifyDialog { get; set; }
    
        // ...
    }
