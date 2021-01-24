    public class ShellViewModel : Conductor<IScreen>.Collection.AllActive
    {
        public ShellViewModel()
        {
            Items.Add(new ChildViewModel());
            Items.Add(new ChildViewModel());
            Items.Add(new ChildViewModel());
        }
    }
