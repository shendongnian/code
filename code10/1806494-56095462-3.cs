    namespace StackHelp
    {
       public partial class MyMainWindow : Window
       {
          // you would have your own view model that all bindings really go to
          MyViewModel VM;
    
          public MyMainWindow()
          {
             // Create instance of the view model and set the window binding 
             // to this public object's DataContext
             VM = new MyViewModel();
             DataContext = VM;
    
             // Now, draw the window and controls
             InitializeComponent();
          }
    
          // for the form button, just to force a refresh of the data.
          // you would obviously have your own method of querying data and refreshing.
          // I am not obviously doing that, but you have your own way to do it.
          private void Button_Click(object sender, RoutedEventArgs e)
          {
             // call my viewmodel object to refresh the data from whatever
             // data origin .. sql, text, import, whatever
             VM.Button_Refresh();
          }
       }
    }
