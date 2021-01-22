    public class ItemViewModel
    {
      public Thickness Margin { get; private set }
    
      public ItemViewModel(ModelClass model)
      {
        /// you can calculate needed margin here, probably depending on some value from Model
        this.Margin = new Thickness(model.TopMargin,0,0,0);
      }
    }
