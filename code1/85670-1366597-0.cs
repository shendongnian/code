    public class PerSessionLifestyleManager : AbstractLifestyleManager
    	{
		private readonly string PerRequestObjectID = "PerSessionLifestyleManager_" + Guid.NewGuid().ToString();
		public override object Resolve(CreationContext context)
		{
			if (HttpContext.Current.Session[PerRequestObjectID] == null)
			{
				// Create the actual object
				HttpContext.Current.Session[PerRequestObjectID] = base.Resolve(context);
			}
			return HttpContext.Current.Session[PerRequestObjectID];
		}
		public override void Dispose()
		{
		}
	}
  
