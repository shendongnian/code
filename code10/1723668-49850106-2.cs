    private static ManualResetEvent _continue;
    int ButtonData;
    
    private void MyButton_Click(object sender, EventArgs e) {
       ButtonData = 5; //example      
       _ev.Set();
    }
    
    private void MyForm_Shown(object sender, EventArgs e) {
       Task t = Task.Run(()=>{
          _continue.Wait(); // there are versions with timeouts as well
    
          // now if the program reaches this line, it means that we can use the ButtonData.
       });
    }
