    private Material _mat;
    void Start()
    {
        Renderer nRend = GetComponent<Renderer>();
        _mat = nRend.material;
    }
    void Update()
    {
        Color nNew = //do whatever you want here
        _mat.SetColor("_BaseColor", nNew);
    }
