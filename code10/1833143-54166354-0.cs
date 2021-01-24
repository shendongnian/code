	public  class Pawn : Piece
	{ // class for a single pawn piece
		public Pawn() //   << RED SYNTAX ERROR RIGHT HERE
		{
			bool FirstMove = true;
			Left = 0;
			Right = 0;
			Up = 2;  //< start it at two?-
			Back = 0;
			DTopLeft = 0; //start these off at zero- 
			DTopRight = 0; // - ^ 
			DBotLef = 0;  // < always -0-
			DBotRite = 0; //  < always -0-
		}
		public override void Move()
		{
			base.Move();// <<==- replace
		}
	}
