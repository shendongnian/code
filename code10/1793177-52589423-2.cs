    public class ViewModel 
    {
         
         public ObservableCollection<Model> Collection { get; set;}         
         public ViewModel()
         {
              Collection = new ObservableCollection<Model>();
              //Now Items can be added, via code behind, or UI !
         }
    }
