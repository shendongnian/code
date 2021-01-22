	public class KeyPress
	{
		public KeyPress(KeyboardState KeyboardState, Keys Key)
		{
			state = KeyboardState;
			key = Key;
			isHeld = false;
		}
		public bool IsPressed { get { return isPressed(); } }
		private Keys key;
		private bool isHeld;
		private static KeyboardState state;
		private bool isPressed()
		{
			if (state.IsKeyDown(key))
			{
				if (isHeld) return false;
				else
				{
					isHeld = true;
					return true;
				}
			}
			else
			{
				if (isHeld) isHeld = false;
				return false;
			}
		}
	}
