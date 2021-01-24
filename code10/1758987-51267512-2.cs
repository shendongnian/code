    public class Window
    {
       public Window()
       {
           InitializeComponent();
           var vm = new XViewModel();
           vm.Name = "My Name";
           DataContext = vm;
       }
    }
