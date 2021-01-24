    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    
    namespace Project.Utilities.Attributes
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class DynamicAuthorizeHttp : AuthorizeAttribute
        {
            protected override bool IsAuthorized(HttpActionContext actionContext)
            {
                if (actionContext == null)
                {
                    throw new ArgumentNullException("actionContext");
                }
    
                IPrincipal user = actionContext.ControllerContext.RequestContext.Principal;
                if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
                {
                    return false;
                }
    
                if (SplitString(Users).Length > 0 && !(SplitString(Users).Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase)))
                {
                    return false;
                }
    
                // Role preparation
                List<string> allowedRolesRaw = new List<string>(SplitString(Roles));
                string allowedRolesAd = "";
    
                allowedRolesRaw.ForEach(rc => allowedRolesAd += DomainMapper.GetRolesActiveDirectoryGroupName(DomainMapper.GetRoleIdFromAttributeName(rc), true) + ", ");
    
    
                if (SplitString(Roles).Length > 0 && !(SplitString(allowedRolesAd).Any(user.IsInRole)))
                {
                    return false;
                }
    
                return true;
            }
    
            internal static string[] SplitString(string original)
            {
                if (String.IsNullOrEmpty(original))
                {
                    return new string[0];
                }
    
                var split = from piece in original.Split(',')
                            let trimmed = piece.Trim()
                            where !String.IsNullOrEmpty(trimmed)
                            select trimmed;
                return split.ToArray();
            }
        }
    }
