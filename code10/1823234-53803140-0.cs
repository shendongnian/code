	public InputField Speed;
	public InputField Grav;
	public InputField Angle;
	public float gravity;
	public float InitialSpeed;
	public float LaunchAngle;
	private void Start()
	{
		gravity = float.Parse(Grav.text);
        InitialSpeed = float.Parse(Speed.text);
        LaunchAngle = float.Parse(Angle.text);
	}
