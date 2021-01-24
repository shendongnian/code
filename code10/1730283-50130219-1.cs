    Rigidbody currentRigidBody;
	FixedJoint fixedJointObj;
	// Use this for initialization
	void Start () 
    {
		currentRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			currentRigidBody.AddForce(new Vector3(-1, 0, 0));
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			currentRigidBody.AddForce(new Vector3(1, 0, 0));
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			currentRigidBody.AddForce(new Vector3(0, 1, 0));
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			currentRigidBody.AddForce(new Vector3(0, -1, 0));
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if(fixedJointObj == null )
			fixedJointObj = gameObject.AddComponent<FixedJoint>();
		Rigidbody body2;
		if ((body2 = collision.gameObject.GetComponent<Rigidbody>()) == null)
			return;
		fixedJointObj.connectedBody = body2;
	}
