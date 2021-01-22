    public class ItemViewModel
    {
      public Thickness Margin { get; private set }
    
      public ItemViewModel(ModelClass model)
      {
        /// You can calculate needed margin here, 
        /// probably depending on some value from the Model
        this.Margin = new Thickness(0,model.TopMargin,0,0);
      }
    }
