    void Start()
    {
        ...
        MoveObjects moveObjects = gameObject.GetComponent<MoveObjects>();
        StartCoroutine(BuildStairs(moveObjects));
    }
