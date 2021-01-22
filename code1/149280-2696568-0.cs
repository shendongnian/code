	public class ClassX
	{
		private ClassY _Y;
		public ClassY Y
		{
			get { return _Y; }
			set
			{
				if (_Y != value)
				{
					var oldY = _Y;
					_Y = value;
					if (_Y == null)
					{
						oldY.X = null;
					}
					else
					{
						_Y.X = this;	
					}
				}
			}
		}
	}
	public class ClassY
	{
		private ClassX _X;
		public ClassX X
		{
			get { return _X; }
			set
			{
				if (_X != value)
				{
					var oldX = _X;
					_X = value;
					if (_X == null)
					{
						oldX.Y = null;
					}
					else
					{
						_X.Y = this;	
					}
					
				}
			}
		}
	}
