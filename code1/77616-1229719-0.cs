    public void OriginalFunction() {
        if ( isTrue ) {
            string [] fileEntries = Directory.GetFiles(LogsDirectory, SystemLogFormat);
            foreach(string fileName in fileEntries) {
                ProcessFile(fileName);
            }
        } else {
            ProcessFile(SingleFileName);
        }
    
    }
    
    public void ProcessFile( string name ) {
        using (StreamReader r = new StreamReader(name))
        {
           // Do a bunch of stuff
        }
    }
