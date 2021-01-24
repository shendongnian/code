    public Camera cam;
    public int SIZE = 5;
    void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        if (!Input.GetMouseButton(0))
            return;
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;
 
        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;
        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
            return;
        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        //Expand where to draw on both direction
        for (int i = 0; i < SIZE; i++)
        {
            int x = (int)pixelUV.x;
            int y = (int)pixelUV.y;
            //Increment the X and Y
            x += i;
            y += i;
            //Apply
            tex.SetPixel(x, y, Color.red);
            //De-increment the X and Y
            x = (int)pixelUV.x;
            y = (int)pixelUV.y;
            x -= i;
            y -= i;
            //Apply
            tex.SetPixel(x, y, Color.red);
        }
        tex.Apply();
    }
