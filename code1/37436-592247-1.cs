    public void SaveData(Action<Table> saveFunc){
        var t = new Table();
        ... 20 lines of code which put stuff into t ...
        saveFunc(t);
    }
    
    SaveData( t => StoredProc1.Invoke(t) ); // save using StoredProc1
    SaveData( t => StoredProc37.Invoke(t) ); // save using StoredProc37
