void MyHandler(object sender, UnhandledExceptionEventArgs e) 
{ 
   if (firstTime){
        Exception exception = e.ExceptionObject as Exception; 
        MessageBox.Show(exception.Message, "ERROR", 
                        MessageBoxButton.OK, MessageBoxImage.Error); 
        firstTime = false;
   }else{
        // Now kill the process....
   }
} 
