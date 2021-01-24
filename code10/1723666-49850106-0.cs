    private static ManualResetEvent _continue;
    int ButtonData;
    
    private void MyButton_Click(object sender, EventArgs e) {
       _ev.Set();
       ButtonData = 5; //example      
    }
    
    private void MyForm_Shown(object sender, EventArgs e) {
       Task t = Task.Run(()=>{
          _continue.Wait(); // there are vdersions with timeouts as welll
    
          // now if the program reaches this line, it means that we can use the ButtonData.
       });
    }
