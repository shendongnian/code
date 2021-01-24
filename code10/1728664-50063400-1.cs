    public float FireRate;
	public float NextFire;
	private List<KeyCode> keysPressed;
	private KeyCode right = KeyCode.RightArrow;
	private KeyCode left = KeyCode.LeftArrow;
	private KeyCode up = KeyCode.UpArrow;
	private KeyCode down = KeyCode.DownArrow;
    private void Awake()
    {
        keysPressed = new List<KeyCode>();
    }
	private void Update()
	{
		if(Input.GetKeyDown(right))
			AddKey(right);
		if(Input.GetKeyDown(left))
			AddKey(left);
		if(Input.GetKeyDown(up))
			AddKey(up);
		if(Input.GetKeyDown(down))
			AddKey(down);
		if(Input.GetKeyUp(right))
			RemoveKey(right);
		if(Input.GetKeyUp(left))
			RemoveKey(left);
		if(Input.GetKeyUp(up))
			RemoveKey(up);
		if(Input.GetKeyUp(down))
			RemoveKey(down);
		if((Time.time > NextFire) == false)
			return;
		if(Input.GetKey(right) || Input.GetKey(left) || Input.GetKey(up) || Input.GetKey(down))
		{
			NextFire = Time.time + FireRate;
			Fire();
		}
	}
	private void AddKey(KeyCode k)
	{
		keysPressed.Add(k);
	}
	private void RemoveKey(KeyCode k)
	{
		keysPressed.Remove(k);
	}
	private void Fire()
	{
		if(keysPressed[keysPressed.Count - 1] == right)
			Debug.Log("right");
		else if(keysPressed[keysPressed.Count - 1] == left)
			Debug.Log("left");
		else if(keysPressed[keysPressed.Count - 1] == up)
			Debug.Log("up");
		else if(keysPressed[keysPressed.Count - 1] == down)
			Debug.Log("down");
	}
