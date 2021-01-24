     public class MainViewModel: INotifyPropertyChanged
     {
         private CategoryViewModel CategoryViewModel {get;set;}
         private ItemsViewModel ItemsViewModel {get;set;}
         public MainViewModel()
         {   
             this.InitializeCommands();
             this.ItemsViewModel = new ItemsViewModel();
             this.CategoryViewModel = new CategoryViewModel();
             //wire up the event 
             this.CategoryViewModel.OnChanged += (s,e) => {
                //perform update here
                this.ItemsViewModel.UpdateWithId(this.CategoryViewModel.SelectedId);
            };
         }
        ///...
     }
