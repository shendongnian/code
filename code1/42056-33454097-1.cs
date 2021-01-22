     private void button1_Click(object sender, EventArgs e)
     {
            
          Thread t = new Thread(new ThreadStart(ThreadJob));
          t.IsBackground = true;
          t.Start();         
     }
            
     private void ThreadJob()
     {
         string newValue= "Hi";
         Thread.Sleep(2000); 
            
         this.Invoke((MethodInvoker)delegate
         {
             label1.Text = newValue; 
         });
     }
