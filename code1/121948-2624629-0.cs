	/// <summary>
	/// Replaces framework-provided RequireHttpsAttribute to disable SSL requirement for local requests 
	/// and properly enforce SSL requirement when used with Rackspace Cloud's load balancer
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public class RequireHttpsAttribute : FilterAttribute, IAuthorizationFilter
	{
		public virtual void OnAuthorization(AuthorizationContext filterContext) {
			if (filterContext == null) {
				throw new ArgumentNullException("filterContext");
			}
			if (filterContext.HttpContext.Request.IsLocal)
				return;
			if (!filterContext.HttpContext.Request.IsSecureConnection()) {
				HandleNonHttpsRequest(filterContext);
			}
		}
		protected virtual void HandleNonHttpsRequest(AuthorizationContext filterContext) {
			// only redirect for GET requests, otherwise the browser might not propagate the verb and request
			// body correctly.
			if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)) {
				throw new InvalidOperationException("The requested resource can only be accessed via SSL.");
			}
			// redirect to HTTPS version of page
			string url = "https://" + filterContext.HttpContext.Request.Url.Host + filterContext.HttpContext.Request.RawUrl;
			filterContext.Result = new RedirectResult(url);
		}
	}
	
	public static class Extensions {
		/// <summary>
        /// Gets a value which indicates whether the HTTP connection uses secure sockets (HTTPS protocol). Works with Rackspace Cloud's load balancer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsSecureConnection(this HttpRequestBase request) {
            const string rackspaceSslVar = "HTTP_CLUSTER_HTTPS";
            return (request.IsSecureConnection || (request.ServerVariables[rackspaceSslVar] != null || request.ServerVariables[rackspaceSslVar] == "on"));
        }
        /// <summary>
        /// Gets a value which indicates whether the HTTP connection uses secure sockets (HTTPS protocol). Works with Rackspace Cloud's load balancer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsSecureConnection(this HttpRequest request) {
            const string rackspaceSslVar = "HTTP_CLUSTER_HTTPS";
            return (request.IsSecureConnection || (request.ServerVariables[rackspaceSslVar] != null || request.ServerVariables[rackspaceSslVar] == "on"));
        }
	}
