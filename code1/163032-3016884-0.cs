      BackgroundWorker worker;
      private void RunScriptBackground()
      {
         string path = "c:\\myscript.py";
         if (File.Exists(path))
         {            
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(bw_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            worker.RunWorkerAsync();
         }
      }
    
      private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         // handle completion here
      }
    
      private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         // handle progress updates here
      }
    
      private void bw_DoWork(object sender, DoWorkEventArgs e)
      {
         // following assumes you have setup IPy engine and scope already
         ScriptSource source = engine.CreateScriptSourceFromFile(path);
         var result = source.Execute(scope);
      }
