	public class PlayerMovedEventArgs
	{
		public Vector2 Delta { get; set; }
		public Vector2 Position { get; set; }
	}
	
	public delegate void PlayerMovedHandler(object sender, PlayerMovedEventArgs e);
