    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var subNodes = new List<ITreeNode>
            {
                new SubNode { Name = "Sub Node 1" },
                new SubNode { Name = "Sub Node 2" },
                new SubNode { Name = "Sub Node 3" },
                new SubNode { Name = "Sub Node 4" }
            };
            var nodes = new List<ITreeNode>
            {
                new Thread { Name = "Thread 1", ChildNodes = subNodes },
                new Thread { Name = "Thread 2", ChildNodes = subNodes },
                new Module { Name = "Module 1", ChildNodes = subNodes },
                new Module { Name = "Module 2", ChildNodes = subNodes }
            };
            var processes = new List<Process>
            {
                new Process{ Name = "Process1", ChildNodes = nodes },
                new Process{ Name = "Process2", ChildNodes = nodes }
            };
            TreeView.ItemsSource = processes;
        }
    }
    public interface ITreeNode
    {
        string Name { get; set; }
        List<ITreeNode> ChildNodes { get; set; }
    }
    public class Process : ITreeNode
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }
    }
    public class Module : ITreeNode
    {
        public string Name { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }
    }
    public class Thread : ITreeNode
    {
        public string Name { get; set; }
        public int ID { get; set; }        
        public List<ITreeNode> ChildNodes { get; set; }
    }
    public class SubNode : ITreeNode
    {
        public string Name { get; set; }
        public List<ITreeNode> ChildNodes { get => null; set => throw new System.NotImplementedException(); }
    }
