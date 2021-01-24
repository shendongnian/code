	class Vector3
	{
		public Vector3(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}
		
		public float X { get; set; }
		public float Y { get; set; }
		
		public static implicit operator (float, float)(Vector3 value)
		{
			return (value.X, value.Y);
		}
	
		public static implicit operator Vector3 ((float, float) value)
		{
			return (value.Item1, value.Item2);
		}
	}
