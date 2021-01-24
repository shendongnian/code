    public class NamesClass : DependencyObject
    {
       public ObservableCollection<string> Names {get; private set; }
       public TestClass()
       {
                this.Names = new ObservableCollection<string>();
       }
    }
