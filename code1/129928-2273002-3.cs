    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //4 instances, each with a property Test of another boolean value
            box.ItemsSource = new[] {
                new {Test = true}, 
                new {Test = false}, 
                new {Test = false}, 
                new {Test = true}
            };
            box.Items.SortDescriptions.Add(new SortDescription("Test", ListSortDirection.Descending));
        }
    }
    public class BooleanHolder
    {
        public bool Test { get; set; }
    }
