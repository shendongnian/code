    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Routing;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    
    namespace redacted.WebApi.Test {
    	using Core;
    
    	public class VerifyDependencies {
    		[Theory]
    		[MemberData(nameof(Controllers))]
    		public void VerifyController(Type controllerType) {
    			var services = new WebHostBuilder().UseStartup<Startup>().Build().Services;
    			ControllerUtilities.Create(
    				controllerType,
    				services.GetService<IControllerActivator>(),
    				services.GetService<IServiceProvider>()
    			);
    		}
    
    
    		public static IEnumerable<object[]> Controllers() {
    			return ControllerUtilities.GetControllers<ApiController>().Select(c => new object[] { c });
    		}
    	}
    
    	public class ControllerUtilities {
    		public static IEnumerable<Controller> GetControllers<TProject>() {
    			return typeof(TProject)
    				.Assembly.ExportedTypes.OfType<Controller>();
    		}
    
    		public static Controller Create(Type controllerType, IControllerActivator activator, IServiceProvider serviceProvider) {
    			return activator.Create(new ControllerContext(new ActionContext(
    				new DefaultHttpContext {
    					RequestServices = serviceProvider
    				},
    				new RouteData(),
    				new ControllerActionDescriptor {
    					ControllerTypeInfo = controllerType.GetTypeInfo()
    				})
    			)) as Controller;
    		}
    
    		public static TController Create<TController>(IControllerActivator activator, IServiceProvider serviceProvider) where TController : Controller {
    			return Create(typeof(TController), activator, serviceProvider) as TController;
    		}
    	}
    }
