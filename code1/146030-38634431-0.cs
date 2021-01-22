        Task[] _tasks = null;
        
       public void run()
        {
           _tasks = new Task[2]; 
          var task = new Task(() => Download(),TaskCreationOptions.LongRunning);
                    task.Start();
                    _tasks[0] = task;
          var task = new Task(() => Download(),TaskCreationOptions.LongRunning);
                    task.Start();
                    _tasks[1] = task;
 
          Task.WaitAny(_tasks); 
        }
       private void Upload()
       {  Sftp _Sftp = null;
          while (true)
          {
            filesToUpload = GetFiles(Sourcepath);
               Parallel.ForEach(filesToUpload, _fileData =>
               { 
                   if(!_Sftp.Insconnected)
                      {
                       _Sftp = new Sftp(Host, User,Password);
                         _Sftp.Connect();
                      }
                    
                    if(_Sftp.Connected)
                      _Sftp.Put(_fileData.Path, DestinyPath);
               });         
          }
       }
       public void Download()
        {
             Sftp _Sftp = null; 
            While(true)
            {
               if(!_Sftp.Connected)
                      {
                       _Sftp = new Sftp(Host, User,Password);
                         _Sftp.Connect();
                       }
                    
                    if(_Sftp.Connected)
