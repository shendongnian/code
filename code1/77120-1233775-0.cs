    class Folder : CustomTreeViewItem
    {
        // Hidden attributes
        public String ElementID { get; set; }
        // Attributes displayed in the treeview
        public String ElementName { get; set; }
        public ObservableCollection<CustomTreeViewItem> Children { get; set; } // This collection is binded with the GUI defined in XAML
        // Constructor
        public Folder()
        {
            // Fill the treeview with a temporary child as text
            Children = new ObservableCollection<CustomTreeViewItem>();
            Children.Add(new CustomTreeViewItem());
        }
        // Get the Folder Children as Folder
        // Method overriden by the Server class
        public List<Folder> GetChildren()
        {
            System.Threading.Thread.Sleep(5000);
            List<Folder> resu = new List<Folder>();
            Folder f1 = new Folder();
            f1.ElementID = "1";
            f1.ElementName = "folder 1";
            Folder f2 = new Folder();
            f2.ElementID = "2";
            f2.ElementName = "folder 2";
            Folder f3 = new Folder();
            f3.ElementID = "3";
            f3.ElementName = "folder 3";
            Folder f4 = new Folder();
            f4.ElementID = "4";
            f4.ElementName = "folder 4";
            resu.Add(f1);
            resu.Add(f2);
            resu.Add(f3);
            resu.Add(f4);
            return resu;
        }
