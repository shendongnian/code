    public class CompositeDisplayable : IDisplayable {
      public void Add(IDisplayable displayable) {
        // TODO: check for null, cycles, etc...
        _list.Add(displayable);
      }
      public void Remove(IDisplayable displayable) {
        // TODO: check for null
        _list.Remove(displayable);
      }
      public Control GetControl() {
        var control = new Control(); 
        // this assumes Control is also a composite type
        _list.ForEach(displayable => control.Add(displayable.GetControl()));
        return control;
      }
      private List<IDisplayable> _list = new List<IDisplayable>();
    }
