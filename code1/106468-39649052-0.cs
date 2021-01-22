    public void fileSystemWatcher1_Changed( object sender, System.IO.FileSystemEventArgs e )
        {            
            this.fileSystemWatcher1.Changed -= new System.IO.FileSystemEventHandler( this.fileSystemWatcher1_Changed );
            MessageBox.Show( "File has been uploaded to destination", "Success!" );
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler( this.fileSystemWatcher1_Changed );
        }
