    public class Window2
    {
       public Window2(XViewModel vm)
       {
           InitializeComponent();
           DataContext = vm;
       }
    }
    
        // Create XViewModel and pass it to Window 2
        var taskViewModel = new XViewModel();
        //Here you set the property
        taskViewModel.Name = Username;
    
        Window2 X = new Window2(taskViewModel);
       
        // Now the value is correct shown in the textblock
        X.Show();
