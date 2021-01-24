    public class ViewModel
    {
        public ObservableCollection<Model> Items { get; set; }
        public ViewModel()
        {
            Items = new ObservableCollection<Model>
            {
                {new Model{ Enabled = true, Group = "Group1"} },
                {new Model{ Enabled = false, Group = "Group2"} },
                {new Model{ Enabled = false, Group = "Group3"} },
                {new Model{ Enabled = true, Group = "Group4"} },
                {new Model{ Enabled = false, Group = "Group5"} },
                {new Model{ Enabled = false, Group = "Group6"} }
            };
        }
    }
