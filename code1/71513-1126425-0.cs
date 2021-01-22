    public abstract class MyItems : ListViewItem
    {
        public abstract DoOperation();
    }
    public class MyItemA : MyItems
    {
        public override DoOperation()
        { /* whatever a */ }
    }
    
    public class MyItemB : MyItems
    {
        public override DoOperation()
        { /* whatever b */ }
    }
    // in ListView event
    MyItems item = (MyItems)this.SelectedItem;
    item.DoOperation();
