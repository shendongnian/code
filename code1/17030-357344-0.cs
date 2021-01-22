    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Security.Principal;
    using System.Web.Routing;
    using System.Web.Mvc;
    using System.Collections;
    using System.Reflection;
    namespace System.Web.Mvc.Html
    {
        public static class HtmlHelperExtensions
        {
    
            /// <summary>
            /// Shows or hides an action link based on the user's membership status
            /// and the controller's authorize attributes
            /// </summary>
            /// <param name="linkText">The link text.</param>
            /// <param name="action">The controller action name.</param>
            /// <param name="controller">The controller name.</param>
            /// <returns></returns>
            public static string SecurityTrimmedActionLink(
                this HtmlHelper htmlHelper,
                string linkText,
                string action,
                string controller)
            {
                return SecurityTrimmedActionLink(htmlHelper, linkText, action, controller, false, null);
            }
    
            /// <summary>
            /// Enables, disables or hides an action link based on the user's membership status
            /// and the controller's authorize attributes
            /// </summary>
            /// <param name="linkText">The link text.</param>
            /// <param name="action">The action name.</param>
            /// <param name="controller">The controller name.</param>
            /// <param name="showDisabled">if set to <c>true</c> [show link as disabled - 
            /// using a span tag instead of an anchor tag ].</param>
            /// <param name="disabledAttributeText">Use this to add attributes to the disabled
            /// span tag.</param>
            /// <returns></returns>
            public static string SecurityTrimmedActionLink(
                this HtmlHelper htmlHelper, 
                string linkText, 
                string action, 
                string controller, 
                bool showDisabled, 
                string disabledAttributeText)
            {
                if (IsAccessibleToUser(action, controller, HttpContext.Current ))
                {
                    return htmlHelper.ActionLink(linkText, action, controller);
                }
                else
                {
                    return showDisabled ? 
                        String.Format(
                            "<span{1}>{0}</span>", 
                            linkText, 
                            disabledAttributeText==null?"":" "+disabledAttributeText
                            ) : "";
                }
            }
            
            private static IController GetControllerInstance(string controllerName)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type controllerType = GetControllerType(controllerName);
                return (IController)Activator.CreateInstance(controllerType);
            }
    
            private static ArrayList GetControllerAttributes(string controllerName, HttpContext context)
            {
                if (context.Cache[controllerName + "_ControllerAttributes"] == null)
                {
                    var controller = GetControllerInstance(controllerName);
    
                    context.Cache.Add(
                        controllerName + "_ControllerAttributes",
                        new ArrayList(controller.GetType().GetCustomAttributes(typeof(AuthorizeAttribute), true)),
                        null,
                        Caching.Cache.NoAbsoluteExpiration,
                        Caching.Cache.NoSlidingExpiration,
                        Caching.CacheItemPriority.Default,
                        null);
    
                }
                return (ArrayList)context.Cache[controllerName + "_ControllerAttributes"];
            
            }
    
            private static ArrayList GetMethodAttributes(string controllerName, string actionName, HttpContext context)
            {
                if (context.Cache[controllerName + "_" + actionName + "_ActionAttributes"] == null)
                {
                    ArrayList actionAttrs = new ArrayList();
                    var controller = GetControllerInstance(controllerName);
                    MethodInfo[] methods = controller.GetType().GetMethods();
    
                    foreach (MethodInfo method in methods)
                    {
                        object[] attributes = method.GetCustomAttributes(typeof(ActionNameAttribute), true);
    
                        if ((attributes.Length == 0 && method.Name == actionName)
                            ||
                            (attributes.Length > 0 && ((ActionNameAttribute)attributes[0]).Name == actionName))
                        {
                            actionAttrs.AddRange(method.GetCustomAttributes(typeof(AuthorizeAttribute), true));
                        }
                    }
    
                    context.Cache.Add(
                        controllerName + "_" + actionName + "_ActionAttributes",
                        actionAttrs,
                        null,
                        Caching.Cache.NoAbsoluteExpiration,
                        Caching.Cache.NoSlidingExpiration,
                        Caching.CacheItemPriority.Default,
                        null);
    
                }
    
                return (ArrayList)context.Cache[controllerName + "_" + actionName+ "_ActionAttributes"]; 
            }
    
            public static bool IsAccessibleToUser(string actionToAuthorize, string controllerToAuthorize, HttpContext context)
            {
                IPrincipal principal = context.User;
                
                //cache the attribute list for both controller class and it's methods
    
                ArrayList controllerAttributes = GetControllerAttributes(controllerToAuthorize, context);
    
                ArrayList actionAttributes = GetMethodAttributes(controllerToAuthorize, actionToAuthorize, context);                        
    
                if (controllerAttributes.Count == 0 && actionAttributes.Count == 0)
                    return true;
                
                string roles = "";
                string users = "";
                if (controllerAttributes.Count > 0)
                {
                    AuthorizeAttribute attribute = controllerAttributes[0] as AuthorizeAttribute;
                    roles += attribute.Roles;
                    users += attribute.Users;
                }
                if (actionAttributes.Count > 0)
                {
                    AuthorizeAttribute attribute = actionAttributes[0] as AuthorizeAttribute;
                    roles += attribute.Roles;
                    users += attribute.Users;
                }
    
                if (string.IsNullOrEmpty(roles) && string.IsNullOrEmpty(users) && principal.Identity.IsAuthenticated)
                    return true;
    
                string[] roleArray = roles.Split(',');
                string[] usersArray = users.Split(',');
                foreach (string role in roleArray)
                {
                    if (role == "*" || principal.IsInRole(role))
                        return true;
                }
                foreach (string user in usersArray)
                {
                    if (user == "*" && (principal.Identity.Name == user))
                        return true;
                }
                return false;
            }
    
            private static Type GetControllerType(string controllerName)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                foreach (Type type in assembly.GetTypes())
                {
                    if (
                        type.BaseType!=null 
                        && type.BaseType.Name == "Controller" 
                        && (type.Name.ToUpper() == (controllerName.ToUpper() + "Controller".ToUpper())))
                    {
                        return type;
                    }
                }
                return null;
            }
    
        }
    }
 
