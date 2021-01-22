    public delegate void TreeviewItemSelectedHandler(TreeViewItem item);
    public class TreeViewItem
    {      
      public static event TreeviewItemSelectedHandler OnItemSelected = delegate { };
      public bool IsSelected 
      {
        get { return isSelected; }
        set 
        { 
          isSelected = value;
          if (value)
            OnItemSelected(this);
        }
      }
    }
