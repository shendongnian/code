	using System.Linq;
	using System.Web.Http.Filters;
	using Umbraco.Core;
	using Umbraco.Core.Models.Membership;
	using Umbraco.Web;
	using Umbraco.Web.Editors;
	using Umbraco.Web.Models.ContentEditing;
	namespace NamespaceHere
	{
		public class RegisterEvents : ApplicationEventHandler
		{
			protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
			{
				EditorModelEventManager.SendingContentModel += EditorModelEventManager_SendingContentModel;
				base.ApplicationStarted(umbracoApplication, applicationContext);
			}
			private void EditorModelEventManager_SendingContentModel(HttpActionExecutedContext sender, EditorModelEventArgs<ContentItemDisplay> e)
			{
				if (e.Model.ContentTypeAlias == "ENTER CONTENT ALIAS HERE")
				{
					IUser currentUser = UmbracoContext.Current.Security.CurrentUser;
					if (!currentUser.Groups.Any(g => g.Name == "Administrators"))
					{
						ContentPropertyDisplay propertyToHide = e.Model.Properties.FirstOrDefault(f => f.Alias == "ENTER PROPERTY ALIAS HERE");
						propertyToHide.Readonly = true;
					}
				}
			}
		}
	}
	
