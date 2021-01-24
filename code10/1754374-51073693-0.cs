    public GameObject elasticobject;
    public float sizingFactor = 0.1f;
    private GameObject lastSpawn = null;
    private float startSize;
    private float startX;
    private float limitX;
    private float limitY;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 size = elasticobject.transform.localScale;
            size.x = Mathf.Clamp(
                startSize + (Input.mousePosition.x - startX) * sizingFactor, 
                0, limitX);
            elasticobject.transform.localScale = size;
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 size = elasticobject.transform.localScale;
            size.y = Mathf.Clamp(
                startSize + (Input.mousePosition.y - startX) * sizingFactor, 
                0, limitY);
            elasticobject.transform.localScale = size;
        }
    }
