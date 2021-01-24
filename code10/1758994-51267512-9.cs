    public class XViewModel
    {
       public XViewModel(String nameProp)
       {
          Name = nameProp;
          MessageBox.Show(Name);
        }
       // Your Properties
       // Your Methods
    }
    // Create XViewModel and pass it to Window 2
    var taskViewModel = new XViewModel();   //HERE where messagebox shows
    //Here you set the property
    taskViewModel.Name = Username;
    
    Window2 X = new Window2(taskViewModel);
       
    // Now the value is correct shown in the textblock
    X.Show();
