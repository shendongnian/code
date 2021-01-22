	public class XmlRepository<T> : IRepository<T>
	{
		private readonly string RelativePath;
		public string Filename { get; private set; }
		public XmlLoader Loader { get; private set; }
		public XmlRepository( HttpContextBase httpContext, XmlLoader loader )
		{
			RelativePath = string.Format( "~/data/{0}.xml" + typeof( T ).Name );
			Filename = httpContext.Server.MapPath( RelativePath );
			Loader = loader;
		}
		public IQueryable<T> GetAll()
		{
			return Loader.Load<List<T>>( Filename ).AsQueryable();
		}
	}
