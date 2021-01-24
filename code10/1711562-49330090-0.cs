    class SaveManager(){
    public static SaveManager Instance;
    Awake(){
    if (Instance == null)
       {
        Instance = this;
       }
    }
    
    List<ISaveable> SaveAbles;
    public void AddSaveAble(ISaveAble saveAble){
    //add it to the list.
    }
    }
    
