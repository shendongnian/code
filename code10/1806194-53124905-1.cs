    public class BusinessViewModel
    {
        public ObservableCollection<TreeData> Items { get; set; } = new ObservableCollection<TreeData>();
        public BusinessViewModel()
        { 
            Items.Add(new TreeData("Root Item", hasChildren: true, GetChildren));
        }
        public List<TreeData> GetChildren()
        {
            return new List<TreeData>()
            {
                new TreeData("Child", hasChildren: false, null);
            };
        }
    }
