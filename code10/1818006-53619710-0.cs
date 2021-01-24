    public class ViewRenderService : IHostedService
    {
    	private readonly IRazorViewEngine _razorViewEngine;
    	private readonly ITempDataProvider _tempDataProvider;
    	private readonly IServiceProvider _serviceProvider;
    
    	public ViewRenderService(IRazorViewEngine razorViewEngine,
    		ITempDataProvider tempDataProvider,
    		IServiceProvider serviceProvider)
    	{
    		_razorViewEngine = razorViewEngine;
    		_tempDataProvider = tempDataProvider;
    		_serviceProvider = serviceProvider;
    	}
    
    	public async Task<string> RenderToStringAsync(string viewName, object model)
    	{
    		using (var requestServices = _serviceProvider.CreateScope())
    		{
    			var httpContext = new DefaultHttpContext { RequestServices = requestServices.ServiceProvider };
    			var routeData = new RouteData();
    			routeData.Values.Add("controller", "Home");
    			var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());
    
    			using (var sw = new StringWriter())
    			{
    				var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);
    
    				if (viewResult.View == null)
    				{
    					throw new ArgumentNullException($"{viewName} does not match any available view");
    				}
    
    				var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
    				{
    					Model = model
    				};
    
    				var viewContext = new ViewContext(
    					actionContext,
    					viewResult.View,
    					viewDictionary,
    					new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
    					sw,
    					new HtmlHelperOptions()
    				);
    
    				await viewResult.View.RenderAsync(viewContext);
    				return sw.ToString();
    			}
    		}
    	}
    
    	public async Task StartAsync(CancellationToken cancellationToken)
    	{
    		var html = await RenderToStringAsync("About", null);
    		return;
    	}
    
    	public async Task StopAsync(CancellationToken cancellationToken)
    	{
    	}
    }
