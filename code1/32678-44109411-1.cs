    public void getId()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
          //Note that, I have collected threadId just before calling 
          //*this.Invoke* 
          //method else it would be same as of UI thread inside the below code 
          //block 
            this.Invoke((MethodInvoker)delegate ()
            {
                inpTxt.Text += "My id is" +"--"+id+Environment.NewLine; 
            });
