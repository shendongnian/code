    string CreateUserURL = "localhost:81/ARFUR/InsertUser.php";
    HashSet<string> list = new HashSet<string>();
    
    string inputUserName = null;
    string inputPassword = null;
    
    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) CreateUser(inputUserName, inputPassword);
    }
    
    public void CreateUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        list.Add(username);
        list.Add(password);
    
        //Loop through each one and send
        foreach (var item in list)
        {
            //Add each one to the Field
            form.AddField("list[]", item);
        }
    
        WWW www = new WWW(CreateUserURL, form);
    }
