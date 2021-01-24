	public abstract class Control
	{
		// Use abstract if you don't want to have a default
		// Draw() method in the base Control:
		public abstract void Draw();
		
		// Use abstract if you do want to have a default
		// Draw() method in the base Control:
		public virtual void Draw()
		{
			// basic drawing code here
		}
	}
