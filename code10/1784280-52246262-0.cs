    public bool movingLeft = false;
    public bool movingRight = false;
    public float speed = 2f;
    public Vector3 moveDirectionLeft = Vector3.left;
    public Vector3 moveDirectionRight = Vector3.right;
    void Start()
    {
        movingLeft = false;
        movingRight = false;
    }
    
    if (movingLeft == true)
    {                      // LEFT BUTTON //
        WalkAnim.SetBool("WalkLeft", true);// walk left
        transform.Translate(moveDirectionLeft * speed * Time.deltaTime);
    }
    else if (movingRight == true)
    {                         // RIGHT BUTTON //
        WalkAnim.SetBool("WalkRight", true); // walks right
        transform.Translate(moveDirectionRight * speed * Time.deltaTime);
    }
    else
    {
        WalkAnim.SetBool("WalkLeft", false);
        WalkAnim.SetBool("WalkRight", false);
    }
    public void limitLD()
    { // UI Button Event trigger - pointUp
        movingLeft = false;
    }
    public void limitRD()
    { // UI Button Event trigger - pointUp
        movingRight = false;
    }
    public void MoveLeft()
    { // UI Button Event trigger - pointDown
        movingLeft = true;
        movingRight = false;
    }
    public void MoveRight()
    { // UI Button Event trigger - pointDown
        movingLeft = false;
        movingRight = true;
    }
