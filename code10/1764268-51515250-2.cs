    private async void Start_Click(object sender, RoutedEventArgs e)
    {
        ReportStart();
        IProgress<FileProgress> progress=new Progress<FileProgress>(ReportProgress);
          ...
        await Task.Run(()=>
        {
            //process starts here
            var fP = new FileProcessor();
       
            foreach(var file in someFiles)
            {
                  progress.Report(new FileProgress(file,0,"Starting");
                  //Do some processing
                  progress.Report(new FileProgress(file,100,"Finished");
            }
            ...
        });
        //We are back in the UI thread, we can modify the UI
        ReportEnd();
    }
