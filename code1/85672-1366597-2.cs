    public class PerSessionLifestyleManager : AbstractLifestyleManager
    	{
		private readonly string PerSessionObjectID = "PerSessionLifestyleManager_" + Guid.NewGuid().ToString();
		public override object Resolve(CreationContext context)
		{
			if (HttpContext.Current.Session[PerSessionObjectID] == null)
			{
				// Create the actual object
				HttpContext.Current.Session[PerSessionObjectID] = base.Resolve(context);
			}
			return HttpContext.Current.Session[PerSessionObjectID];
		}
		public override void Dispose()
		{
		}
	}
  
