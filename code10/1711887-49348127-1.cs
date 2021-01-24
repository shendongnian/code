    public class ViewModel
    {
        public ViewModel()
        {
           this.SelectionCommand = new DelegateCommand<object>(this.SelectionChanges );
        }
     
        public ICommand SelectionCommand { get; private set; }
    
        private void SelectionChanges(object sender)
        {
                 SelectedDatesCollection dates = sender as SelectedDatesCollection;
        } 
    }
