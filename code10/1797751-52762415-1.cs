    private void btn_Click(object sender, EventArgs e)
    {
       var task1 = Task.Factory.StartNew(() => MyMethod()); // you could add some arguments in your method
       var task2 = Task.Factory.StartNew(() => MyMethod()); // maybe with different args
       ...
       ... // as many tasks you want, in your case 5
    }
 
