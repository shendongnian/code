    public GameObject foot1;
    public GameObject foot2;
    
    void Update()
    {
        //Check if feet GameObjects are touching 
        bool touching = CollisionDetection.IsTouching(foot1, foot2);
    
        if (touching)
        {
            Debug.Log("<color=green>leg1 and leg2 touching</color>");
        }
        else
        {
            Debug.Log("leg1 and leg2 NOT touching");
        }
    }
