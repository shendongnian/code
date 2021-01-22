    public class myclass
    {
        // using "automatic" properties
        public TabControl theTabControl { get; set; }
    
        // parameter-less 'ctor
        public myclass()
        {
    
        }
    
        // optional 'ctor where you pass in a reference to the TabControl
        public myclass(TabControl tbControl)
        {
            theTabControl = tbControl;
        }
    
        // an example method that would add a new TabPage to the TabControl
        public void addNewTabPage(string Title)
        {
            theTabControl.TabPages.Add(new TabPage(Title));
        }
    }
