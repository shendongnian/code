    //Request access
    ReaderWriterLockSlim fileLock = null;
    bool needCreate = false;
    lock(Coordination.Instance)
    {
        if(Coordination.Instance.ContainsKey(theId))
        {
            fileLock = Coordination.Instance[theId];
        }
        else if(!fileExists(theId)) //check if the file exists at this moment
        {
            Coordination.Instance[theId] = fileLock = new ReaderWriterLockSlim();
            fileLock.EnterWriteLock(); //give no other thread the chance to get into write mode
            needCreate = true;
        }
        else
        {
            //The file exists, and whoever created it, is done with writing. No need to synchronize in this case.
        }
    }
    if(needCreate)
    {
        createFile(theId); //Writes the file from the database
        lock(Coordination.Instance)
            Coordination.Instance.Remove[theId];
        fileLock.ExitWriteLock();
        fileLock = null;
    }
    if(fileLock != null)
        fileLock.EnterReadLock();
    //read your data from the file
    if(fileLock != null)
       fileLock.ExitReadLock();
 
