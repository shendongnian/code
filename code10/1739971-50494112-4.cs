    public float walkSpeed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0F;
    CharacterController myCharacterController = null;
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }
    void MovePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= walkSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        myCharacterController.Move(moveDirection * Time.deltaTime);
    }
