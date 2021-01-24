    public class YourBaseViewModel
    {   
    	public Object YourBaseProperty{get; set;}
    
        public RelayCommand ButtonCommand { get; private set; }
        
        private void ExecuteButtonCommand(object message)
        {
            //Some method to fill the corresponding textfield
        }
        
        private bool CanExecuteButtonCommand(object message)
        {
            return true;
        }
    }
