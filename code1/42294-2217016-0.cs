    public class BindableListViewModel 
    {
    
         public IList<TypeOfObjectToDisplay> AllObjectsToDisplay;
         public ICommand AddNewItemToList;
    
         public BindableListViewModel()
         { 
           AllObjectsToDisplay = new ObservableList<TypeOfObjectToDisplay>();
           AddNewItemToList = new RelayCommand(AddNewItem(), CanAddNewItem());
         }
         
         public bool CanAddNewItem()
         {
           //logic that determines IF you are allowed to add
           //For now, i'll just say that we can alway add.
            return true;
         }
    
         public void AddNewItem()
         {
           AllObjectsToDisplay.Add(new TypeOfObjectToDisplay());
         }
    
    }
    
