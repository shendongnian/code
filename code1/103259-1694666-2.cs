    public interface IItemAdder
    {
      void AddItem(string value);
    }
    
    public class ListControlItemAdder : IItemAdder
    {
      private readonly ListControl _listControl;
    
      public ListControlItemAdder(ListControl listControl)
      {
        _listControl = listControl;
      }
    
      public void AddItem(string value)
      {
        _listControl.Items.Add(value);  // or new ListItem(value, value) per your original code
      }
    }
    
    public class RadioButtonListItemAdder : IItemAdder
    {
      // ...
      public void AddItem(string value)
      {
        // do whatever you have to do to add an item to a list of RadioButtons
      }
    }
    
    public static IItemAdder CreateItemAdderFor(Control control)
    {
      if (control is ListControl)
        return new ListControlItemAdder((ListControl)control);
      else if (control is RadioButtonList)
        return new RadioButtonListItemAdder((RadioButtonList)control);
      // etc. to cover other cases
    }
    
    public static Control ConfigureControl(Control control, ...)
    {
      // ... omitting code that looks like your existing code ...
      IItemAdder itemAdder = CreateItemAdderFor(control);
      foreach (string val in popValues)
        itemAdder.AddItem(val);
    }
