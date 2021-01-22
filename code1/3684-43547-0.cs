	class A
	{
		public virtual void Render()
		{
		}
	}
	class B : A
	{
		public override void Render()
		{
			// Prepare the object for rendering       
			SpecialRender();
			// Do some cleanup    
		}
		protected virtual void SpecialRender()
		{
		}
	}
	class B2 : B
	{
		public new void Render()
		{
		}
	}
	class C : B2
	{
		protected override void SpecialRender()
		{
		}
		//public override void Render() // compiler error 
		//{
		//}
	}
