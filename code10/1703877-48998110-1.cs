	public class RenderGrid 
	{
		public Vector2 bottomLeft;
		public Vector2 topRight;
		public Player _player;
		
		public event PlayerMovedHandler Changed;
	
		public RenderGrid(Player player) 
		{
			_player = player;
			_player.OnPlayerMoved += PlayerMovedInGrid;
		}
	
		private void UpdateCorners(Vector2 delta, Vector2 position)
		{
			//ToDo: Update corners
		}
		private void PlayerMovedInGrid(object sender, PlayerMovedEventArgs e) 
		{
			UpdateCorners(e.Delta, e.Position);
			OnChanged(e);
		}
		
		protected void OnChanged(PlayerMovedEventArgs e)
		{
			if (Changed != null) Changed(this, e);
		}
	}
