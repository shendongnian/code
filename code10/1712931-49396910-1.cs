    public class ViewModel : ViewModelBase
    { 
        private string groupAddress;
		public string GroupAddress
		{
			get
			{
				return groupAddress;
			}
			
			set
			{
				if(value != groupAddress)
				{
					groupAddress = value;
					OnPropertyChanged("GroupAddress");
					
				}
			}
		}
 
        public ViewModel() 
        { 
              
        } 
 
        private ICommand clickCommand; 
        public ICommand ClickCommand 
        { 
            get 
            { 
                return clickCommand ?? (clickCommand = new CommandHandler(() => MyAction(), true)); 
            } 
        } 
 
        public void MyAction() 
        { 
            GroupAddress = "New Group Address"; 
        } 
    }
	
