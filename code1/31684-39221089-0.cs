    public partial class MyWindow: Window
    {
        public ApplicationSelection()
        {
          InitializeComponent();
          MyViewModel viewModel = new MyViewModel();
      
          DataContext = viewModel;
          viewModel.RequestClose += () => { Close(); };
      
        }
    }
    public class MyViewModel
    {
      
      //...Your code...
      public event Action RequestClose;
      public virtual void Close()
      {
        if (RequestClose != null)
        {
          RequestClose();
        }
      }
      public void SomeFunction()
      {
         //...Do something...
         Close();
      }
    }
