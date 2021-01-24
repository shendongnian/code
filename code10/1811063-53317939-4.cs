     public class MainViewModel: INotifyPropertyChanged
     {
         public CategoryViewModel CategoryViewModel {get;set;}
         public ItemsViewModel ItemsViewModel {get;set;}
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
