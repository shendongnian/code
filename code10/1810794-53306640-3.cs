    public float horiz;
    public float vert;
    void Start() {
        horiz = 0f;
        vert = 0f;
        if (Input.GetKey(KeyCode.A)) horiz -= 1f;
        if (Input.GetKey(KeyCode.D)) horiz += 1f;
        if (Input.GetKey(KeyCode.S)) vert -= 1f;
        if (Input.GetKey(KeyCode.W)) vert += 1f;
    }
    
    void Update () {
        Vector2 oldV = rigid.velocity;
        if(Input.GetKeyDown(KeyCode.W)) vert += 1f;
        else if(Input.GetKeyUp(KeyCode.W)) vert -= 1f;
    
        if (Input.GetKeyDown(KeyCode.S)) vert -= 1f;
        else if (Input.GetKeyUp(KeyCode.S)) vert += 1f;
    
        if (Input.GetKeyDown(KeyCode.A)) horiz -= 1f;
        else if (Input.GetKeyUp(KeyCode.A)) horiz += 1f;
    
        if (Input.GetKeyDown(KeyCode.D)) horiz += 1f;
        else if (Input.GetKeyUp(KeyCode.D)) horiz -= 1f;
        Vector2 newV = new Vector2(horiz * Speed, vert * Speed);
        rigid.AddForce(newV-oldV, ForceMode2D.Impulse);
    }
    
