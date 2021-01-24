    List<string> userList = new List<string> { "User1", "User2", "User3" };
    [SerializeField]
    private Text TextUserPrefabRef;
    [SerializeField]
    private Button ButtonAddUserPrefabRef;
    [SerializeField]
    private GameObject ScrollViewUsersSamplePrefabRef;
    [SerializeField]
    private Transform PanelFindFriendsRef;
    private Transform ContentUsers;
    public void CreateNew () 
    {
        if (GameObject.Find("ScrollViewUsers") != null)
        {
            Debug.Log("Destroying");
            Destroy(GameObject.Find("ScrollViewUsers"));
        }
        GameObject scrollView = Instantiate(ScrollViewUsersSamplePrefabRef, PanelFindFriendsRef);
        scrollView.name = "ScrollViewUsers";
        ContentUsers = scrollView.transform.Find("Viewport/ContentUsersSample");
        ContentUsers.name = "ContentUsers";
        foreach (string user in userList)
        {
            Debug.Log("user=" + user);
            GameObject newTextUser = Instantiate (TextUserPrefabRef.gameObject, ContentUsers) as GameObject;
            newTextUser.GetComponent<Text>().text = user;
            GameObject newButton = Instantiate (ButtonAddUserPrefabRef.gameObject, ContentUsers);
            newButton.name = "addUser_" + user;
        }	
	}
   
