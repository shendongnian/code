	public enum HorizontalDirection
	{
		Left = -1,
		None = 0,
		Right = 1,
	}
	
	public enum VerticalDirection
	{
		Up = -1,
		None = 0,
		Down = 1,
	}
	public struct Direction
	{
		public Direction(HorizontalDirection h) : this(h, VerticalDirection.None) { }
		public Direction(VerticalDirection v) : this(HorizontalDirection.None, v) { }
		
		public Direction(HorizontalDirection h, VerticalDirection v)
		{
			HorizontalComponent = h;
			VerticalComponent = v;
		}
		
		public HorizontalDirection HorizontalComponent { get; }
		public VerticalDirection VerticalComponent { get; }
		
		public Direction Invert() => new Direction(
			(HorizontalDirection)(-(int)HorizontalComponent),
			(VerticalDirection)(-(int)VerticalComponent));
	}
