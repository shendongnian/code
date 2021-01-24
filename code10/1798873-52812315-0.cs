    public Transform target;
    Vector3 fineMovimento;
    float smoothTime = 0.125f;
    
    void Start()
    {
        fineMovimento = target.position;
    }
    void Update () 
    {
        target.position = Vector3.Lerp(target.position, fineMovimento, smoothTime);
        if (Input.GetKeyDown(KeyCode.P))
        {
            fineMovimento = new Vector3(221.04f, -8.98f,329);
        }
    }
