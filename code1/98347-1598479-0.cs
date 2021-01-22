	/// <summary>
	/// Represents a special controller factory.
	/// </summary>
	public class CastleWindsorControllerFactory : DefaultControllerFactory
	{
		WindsorContainer _container;
	
		public CastleWindsorControllerFactory()
		{
			// register all controllers from the calling assembly.
			// (e.g. the mvc site calling this factory)
			//
			_container =
				new WindsorContainer(
					new XmlInterpreter(
						new ConfigResource("castle")
					)
				);
			// change this to Assembly.GetAssembly() if used directly from
			// your MVC website.  The code below is for when this class
			// exists in a seperate assembly.
			//
			var controllers =
				from t in Assembly.GetCallingAssembly().GetTypes()
				where typeof(IController).IsAssignableFrom(t)
				select t;
	
			foreach (Type t in controllers)
				_container.AddComponentLifeStyle(
					t.FullName, t, LifestyleType.Transient); 
		}
	
		protected override IController GetControllerInstance(Type controllerType)
		{
			if (controllerType == null)
			{
				throw new HttpException(
					0x194
					, string.Format(
						CultureInfo.CurrentUICulture
						, "Controller Not Found"
						, new object[] {
							this.RequestContext.HttpContext.Request.Path }));
			}
			if (false == typeof(IController).IsAssignableFrom(controllerType))
			{
				throw new ArgumentException(
					string.Format(
						CultureInfo.CurrentUICulture
						, "Type does not sub-class the controller base"
						, new object[] { controllerType }), "controllerType");
			}
			return 
				(IController) _container.Resolve(controllerType);
		}
	}
