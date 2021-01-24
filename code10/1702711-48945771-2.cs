    public class EmployeeResultsViewModel : ViewModelBase
    {
        private async Task LoadEmployee()
        {
            EmployeeResults = GetDataUsingAPI(); //15 records per call
			
			DeleteCommand = new Command<ExtendedEmployee>(OnDelete);
        }
    
        public ICommand DeleteCommand { get; }
		
		private void OnDelete(ExtendedEmployee employee)
		{
		    // delete the employee from the collection
		}
    
        /* ... */
    }
