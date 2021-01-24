     public class YourMainViewModel : INotifyPropertyChanged
     {
         private CategoryViewModel _categoryViewModel {get;set;}
         private ItemsViewModel _itemsViewModel {get;set;}
         public YourMainViewModel()
         {
             _categoryViewModel  = new CategoryViewModel();
             //wire up the event 
             _categoryViewModel.OnChanged += (s,e) => {
                //perform update here
            }
         }
        ///...
     }
