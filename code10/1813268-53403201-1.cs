    // ...
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private static bool playerExists;
    public GameObject cameraPrefab; 
    public GameObject mainCamera; // add this line
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        if(!playerExists){
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }
        targetPos = transform.position;
        mainCamera = (GameObject)Instantiate(cameraPrefab); // use mainCamera field
        mainCamera.tag = "MainCamera"; // tell Unity that it is your main camera.
    }
    // ...
