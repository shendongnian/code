     private void button2_Click(object sender, EventArgs e) 
         { 
             BackgroundWorker worker = new BackgroundWorker(); 
             worker.DoWork += new DoWorkEventHandler(worker_DoWork); 
             worker.RunWorkerAsync(); 
         } 
        
         private delegate void UpdateProgDelegate(int count); 
         private void UpdateText(int count) 
         { 
             if (this.lblTest.InvokeRequired) 
             { 
                 UpdateProgDelegate updateCallBack = new UpdateProgDelegate(UpdateText); 
                 this.Invoke(updateCallBack, new object[] { count }); 
             } 
             else 
             { 
                 lblTest.Text = count.ToString(); 
             } 
         } 
        
         void worker_DoWork(object sender, DoWorkEventArgs e) 
         {   
             /* Old Skool delegate usage.  See above for delegate and method definitions */ 
             for (int i = 0; i < 50; i++) 
             { 
                 UpdateText(i); 
                 Thread.Sleep(50); 
             } 
        
             // Anonymous Method 
             for (int i = 0; i < 50; i++) 
             { 
                 lblTest.Invoke((MethodInvoker)(delegate() 
                 { 
                     lblTest.Text = i.ToString(); 
                 })); 
                 Thread.Sleep(50); 
             } 
        
             /* Lambda using the new Func delegate. This lets us take in an int and 
              * return a string.  The last parameter is the return type. so 
              * So Func<int, string, double> would take in an int and a string 
              * and return a double.  count is our int parameter.*/ 
             Func<int, string> UpdateProgress = (count) => lblTest.Text = count.ToString(); 
             for (int i = 0; i < 50; i++) 
             { 
                 lblTest.Invoke(UpdateProgress, i); 
                 Thread.Sleep(50); 
             } 
             
             /* Finally we have a totally inline Lambda using the Action delegate 
              * Action is more or less the same as Func but it returns void. We could 
              * use it with parameters if we wanted to like this: 
              * Action<string> UpdateProgress = (count) => lblT…*/ 
             for (int i = 0; i < 50; i++) 
             { 
                 lblTest.Invoke((Action)(() => lblTest.Text = i.ToString())); 
                 Thread.Sleep(50); 
             } 
         }
