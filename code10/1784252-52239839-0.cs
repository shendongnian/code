    public Transform body;
    public Transform head;   
    public float rotationSpeed;	
    
    void Update()
    {
        var amountX = (-Input.GetAxis("Mouse Y")) * Time.deltaTime * rotationSpeed;
        var amountY =   Input.GetAxis("Mouse X")  * Time.deltaTime * rotationSpeed;
       
        head.Rotate(body.up,    amountY, Space.World);        
        head.Rotate(head.right, amountX, Space.World);
    }
