    public class ManagedEspritToolbar : Esprit.Toolbar
    {
        public ToolbarControl get_Item(int index) => Toolbar[index];
    
        public void set_Item(int index, ToolbarControl value) => Toolbar[index] = value;
    }
