    public void fileSystemWatcher1_Changed( object sender, System.IO.FileSystemEventArgs e )
        {            
            fileSystemWatcher1.Changed -= new System.IO.FileSystemEventHandler( fileSystemWatcher1_Changed );
            MessageBox.Show( "File has been uploaded to destination", "Success!" );
            fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler( fileSystemWatcher1_Changed );
        }
