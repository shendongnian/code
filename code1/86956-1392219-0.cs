    public class FooForm: Form
    {
    
       //This is just a button click handler that calls ShowMessage from another thread.
       private void ButtonShowMessage_Click(object sender,EventArgs e)
       {
         //Use this to see that you can't interact with FooForm before closing the messagebox.
         ThreadPool.QueueUserWorkItem(delegate{ ShowMessage("Hello World!");});
         //Use this (uncomment) to see that you can interact with FooForm even though there is a messagebox.
         //ThreadPool.QueueUserWorkItem(delegate{ MessageBox.Show("Hello World!");});
       }
    
       private void ShowMessage(string message)
       {
         if( InvokeRequire)
         {
           BeginInvoke(new MethodInvoker( () => MessageBox.Show(message))); 
         }
         else
         {
           MessageBox.Show(message);
         }
       }    
    } 
