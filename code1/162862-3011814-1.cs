    public class ListBoxNoRightClickSelect : ListBox
    {
      protected override DependencyObject GetContainerForItemOverride()
      {
        return new ListBoxItemNoRightClickSelect();
      }
    }
