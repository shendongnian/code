    public static MyMonobehaviour Instance;
    void Awake(){
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Update(){
        ...
    }
