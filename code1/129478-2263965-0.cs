    string direcory = "Mydirectory";
    	var jpegFiles = System.IO.Directory.EnumerateFiles(direcory,"*.jpg");
        
        
        // --  PLinq --------------------------------------------
        jpegFiles
        .AsParallel()
    	.Select(imageFile => new {OldLocation = imageFile, NewLocation = GenerateCopyLocation(imageFile) })
        .Do(fileInfo => 
            {
                if (!File.Exists(fileInfo.NewLocation ) || 
                    (File.GetCreationTime(fileInfo.NewLocation)) != (File.GetCreationTime(fileInfo.NewLocation)))
                    File.Copy(fileInfo.OldLocation,fileInfo.NewLocation);
            })
        .Run();
        
        // -----------------------------------------------------
            
        
        //-- Rx Framework ---------------------------------------------
        var resetEvent = new AutoResetEvent(false);
        var doTheWork =
        jpegFiles.ToObservable()
        .Select(imageFile => new {OldLocation = imageFile, NewLocation = GenerateCopyLocation(imageFile) })
        .Subscribe( fileInfo => 
            {
                if (!File.Exists(fileInfo.NewLocation ) || 
                    (File.GetCreationTime(fileInfo.NewLocation)) != (File.GetCreationTime(fileInfo.NewLocation)))
                File.Copy(fileInfo.OldLocation,fileInfo.NewLocation);
            },() => resetEvent.Set());
            
        resetEvent.WaitOne();
        doTheWork.Dispose();
        
        // -----------------------------------------------------
            
