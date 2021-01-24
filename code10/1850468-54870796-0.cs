	/// <summary> Returns a vector which is relative to the facing and position of 'c'. </summary>
	public static Vector3 RelativePosition (Transform c, Vector3 target)
	{
		return c.right * target.x + c.up * target.y + c.forward * target.z + c.position;
	}
	/// <summary> Returns a vector which is relative. </summary>
	public static Vector3 RelativePosition (Vector3 position, Vector3 forward, Vector3 up, Vector3 right, Vector3 target)
	{
		return right * target.x + up * target.y + forward * target.z + position;
	}
