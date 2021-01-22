	public class ParentRequiringAttribute
	{
		public ParentRequiringAttribute()
		{
			if (this.GetType().GetCustomAttributes(typeof(RequiredRandomThingAttribute), false).Length == 0)
				throw new NotImplementedException(this.GetType().ToString());
		}
	}
