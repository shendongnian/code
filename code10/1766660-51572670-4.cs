    public class MyViewModel : ViewModelBase
    {
        private string barriereFreiHelpText = "Here the accessibility of the editor can be activated or deactivated.";
    
        public string BarriereFreiHelpText
        {
            get { return this.barriereFreiHelpText; }
            set
            {
                if (value == this.barriereFreiHelpText)
                {
                    return;
                }
                
                this.barriereFreiHelpText = value;
                this.RaisePropertyChanged(); // This line makes sure the UI is updated 
                                             // whenever a new help text is set.            
                }
        }
    }
