	static class PageBuilder {
		public static readonly string PageDirectory = Path.Combine(Path.GetDirectoryName(typeof(PageBuilder).Assembly.Location), "EmailPages");
		static bool inited;
		public static void InitDomain() {
			if (inited) return;
			var domain = AppDomain.CurrentDomain;
			domain.SetData(".appDomain", "*");
			domain.SetData(".appPath", PageDirectory);
			domain.SetData(".appVPath", "/");
			domain.SetData(".domainId", "MyProduct Domain");
			domain.SetData(".appId", "MyProduct App");
			domain.SetData(".hostingVirtualPath", "/");
			var hostEnv = new HostingEnvironment();//The ctor registers the instance
			//Ordinarily, the following method is called from app manager right after app domain (and hosting env) is created
			//Since CreateAppDomainWithHostingEnvironment is never called here, I need to call Initialize myself.
			//Here is the signaature of the method.
			//internal void Initialize(ApplicationManager appManager, IApplicationHost appHost, IConfigMapPathFactory configMapPathFactory, HostingEnvironmentParameters hostingParameters) { 
			var cmp = Activator.CreateInstance(typeof(HttpRuntime).Assembly.GetType("System.Web.Hosting.SimpleConfigMapPathFactory"));
			typeof(HostingEnvironment).GetMethod("Initialize", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(hostEnv, new[] { ApplicationManager.GetApplicationManager(), null, cmp, null });
			//This must be done after initializing the HostingEnvironment or it will initialize the config system.
			SetDefaultCompilerVersion("v3.5");
			inited = true;
		}
		static void SetDefaultCompilerVersion(string version) {
			var info = CodeDomProvider.GetCompilerInfo("c#");
			var options = (IDictionary<string, string>)typeof(CompilerInfo).GetProperty("ProviderOptions", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(info, null);
			options["CompilerVersion"] = version;
		}
		public static TPage CreatePage<TPage>(string virtualPath) where TPage : Page {
			return BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(TPage)) as TPage;
		}
	//In a base class that inherits Page:
		internal string RenderPage() {
			var request = new SimpleWorkerRequest("", null, null);
			ProcessRequest(new HttpContext(request));
			using (var writer = new StringWriter(CultureInfo.InvariantCulture)) {
				using (var htmlWriter = new HtmlTextWriter(writer))
					RenderControl(htmlWriter);
				return writer.ToString();
			}
		}
