    public sceneIndex = 0; //build index of the scene you want to switch to
    
    private Ray ray;
    private RaycastHit hit;
    [serializefield]
    private LayerMask myMask;//serializing it will give a dropdown menu in the editor to select the mask layer form, can also use int to select the layer
    
    private readonly float rayLength = 10;
    private readonly float timerMax = 5f; //Higher timerMax is a longer wait, lower timerMax is shorter...
    private float timer = 0f;
    
    private void Update()
    {
        ray = Camera.main.ViewportPointToRay(Vector3.forward);
        if (Physics.Raycast(ray, out hit, rayLength, myMask))
        {
            timer += Time.deltaTime;
            if(timer >= timerMax)
            {
                SceneManager.LoadScene(sceneIndex);//load the scene with the build index of sceneIndex
            }
        }
        else
        {
            timer = 0;
        }
    }
