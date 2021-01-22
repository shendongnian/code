		public Base Clone()
		{
			return this.CloneImpl() as Base;
		}
		
		object ICloneable.Clone()
		{
			return this.CloneImpl();
		}
		
		protected virtual object CloneImpl()
		{
			return new Base();
		}
	}
	
	public class Derived : Base
	{
		public new Derived Clone()
		{
			return this.CloneImpl() as Derived;
		}
		
		protected override object CloneImpl()
		{
			return new Derived();
		}
	}
