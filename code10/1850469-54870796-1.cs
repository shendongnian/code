	/// <summary> Returns a vector which is relative to the facing of 'c'. </summary>
	public static Vector3 RelativePositionZero (Transform c, Vector3 target)
	{
		return c.right * target.x + c.up * target.y + c.forward * target.z;
	}
	/// <summary> Returns a vector which is relative. </summary>
	public static Vector3 RelativePositionZero (Vector3 forward, Vector3 up, Vector3 right, Vector3 target)
	{
		return right * target.x + up * target.y + forward * target.z;
	}
