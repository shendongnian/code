	<%@ WebHandler Language="C#" Class="HidePropertiesJsOutput" %>
	using System.Web;
	using System.Web.Security;
	using System.Linq;
	using Umbraco.Core;
	using Umbraco.Core.Services;
	using Umbraco.Core.Security;
	using Umbraco.Core.Models.Membership;
	public class HidePropertiesJsOutput : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			IUserService userService = ApplicationContext.Current.Services.UserService;
			HttpContextWrapper httpCtxWrapper = new HttpContextWrapper(HttpContext.Current);
			FormsAuthenticationTicket umbTicket = httpCtxWrapper.GetUmbracoAuthTicket();
			if (umbTicket != null)
			{
				IUser currentUser = userService.GetByUsername(umbTicket.Name);
				if (!currentUser.Groups.Any(g => g.Name == "Administrators"))
				{
					string propertyAlias = "ENTER PROPERTY ALIAS HERE"
					context.Response.ContentType = "text/javascript";
					context.Response.Write("$(document).arrive(\"div[data-element='property-" + propertyAlias + "']\", function () { $(this).hide(); });\r\n");
				}
			}
		}
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
	
