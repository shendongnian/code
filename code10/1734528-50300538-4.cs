	public class TracingViewEngine : IViewEngine 
	{ 
		private readonly IViewEngine _innerViewEngine;
		public TracingViewEngine(IViewEngine innerViewEngine) 
		{ 
			_innerViewEngine = innerViewEngine; 
		}
		public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, 
			 bool useCache) 
		{ 
			var result = _innerViewEngine.FindPartialView(controllerContext, partialViewName, useCache); 
			return CreateTracingViewEngineResult(result, partialViewName); 
		}
		public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, 
			bool useCache) 
		{ 
			 var result = _innerViewEngine.FindView(controllerContext, viewName, masterName, useCache); 
			return CreateTracingViewEngineResult(result, viewName); 
		}
		public void ReleaseView(ControllerContext controllerContext, IView view) 
		 { 
			TracingView tracingView = (TracingView)view; 
			_innerViewEngine.ReleaseView(controllerContext, tracingView.InnerView); 
		}
		public ViewEngineResult CreateTracingViewEngineResult(ViewEngineResult result, string name) 
		{ 
			if (result.View == null) 
			{ 
				 return result; // no view to wrap 
			} 
			 return new ViewEngineResult(new TracingView(result.View, name), this); 
		} 
	}
