    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Net;
    using System.Net.Cache;
    using System.IO;
    using System.Resources;
    
    namespace AxureExport {
    
    	//
    	// redirect URL resolution to local resource (or cache)
    	public class XmlCustomResolver : XmlUrlResolver {
    
    		ICredentials _credentials;
    		ResourceManager _resourceManager;
    
    		public enum ResolverType { useDefault, useCache, useResource };
    		ResolverType _resolverType;
    
    		public XmlCustomResolver(ResolverType rt, ResourceManager rm = null) {
    			_resourceManager = rm != null ? rm : AxureExport.Properties.Resources.ResourceManager;
    			_resolverType = rt;
    		}
    
    		public override ICredentials Credentials {
    			set {
    				_credentials = value;
    				base.Credentials = value;
    			}
    		}
    
    		public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn) {
    			object response = null;
    	
    			if (absoluteUri == null)
    				throw new ArgumentNullException(@"absoluteUri");
    
    			switch (_resolverType) {
    				default:
    				case ResolverType.useDefault:					// use the default behavior of the XmlUrlResolver
    					response = defaultResponse(absoluteUri, role, ofObjectToReturn);
    					break;
    
    				case ResolverType.useCache:						// resolve resources thru cache
    					if (!isExternalRequest(absoluteUri, ofObjectToReturn)) {
    						response = defaultResponse(absoluteUri, role, ofObjectToReturn);
    						break;
    					}
    
    					WebRequest webReq = WebRequest.Create(absoluteUri);
    					webReq.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
    					if (_credentials != null)
    						webReq.Credentials = _credentials;
    
    					WebResponse wr = webReq.GetResponse();
    					response = wr.GetResponseStream();
    					break;
    
    				case ResolverType.useResource:					// get resource from internal resource
    					if (!isExternalRequest(absoluteUri, ofObjectToReturn)) {
    						response = defaultResponse(absoluteUri, role, ofObjectToReturn);	// not an external request
    						break;
    					}
    
    					string resourceName = uriToResourceKey(absoluteUri);
    					object resource = _resourceManager.GetObject(resourceName);
    					if (resource == null)
    						throw new ArgumentException(@"Resource not found.  Uri=" + absoluteUri + @" Local resourceName=" + resourceName);
    
    					if (resource.GetType() != typeof(System.String))
    						throw new ArgumentException(resourceName + @" is an unexpected resource type.  (Are you setting resource FileType=Text?)");
    
    					response = ObjectToUTF8Stream(resource);
    					break;
    			}
    
    			return response;
    		}
    
    		//
    		// convert object to stream
    		private static object ObjectToUTF8Stream(object o) {
    			MemoryStream stream = new MemoryStream();
    
    			StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
    			writer.Write(o);
    			writer.Flush();
    			stream.Position = 0;
    
    			return stream;
    		}
    
    		//
    		// default response is to call tbe base resolver
    		private object defaultResponse(Uri absoluteUri, string role, Type ofObjectToReturn) {
    			return base.GetEntity(absoluteUri, role, ofObjectToReturn);
    		}
    
    		//
    		// determine whether this is an external request
    		private static bool isExternalRequest(Uri absoluteUri, Type ofObjectToReturn) {
    			return absoluteUri.Scheme == @"http" && (ofObjectToReturn == null || ofObjectToReturn == typeof(Stream));
    		}
    
    		//
    		// translate uri to format compatible with reource manager key naming rules
    		// see: System.Resources.Tools.StronglyTypedResourceBuilder.VerifyResourceName Method
    		//   from http://msdn.microsoft.com/en-us/library/ms145952.aspx:
    		private static string uriToResourceKey(Uri absoluteUri) {
    			const string repl = @"[ \xA0\.\,\;\|\~\@\#\%\^\&\*\+\-\/\\\<\>\?\[\]\(\)\{\}\" + "\"" + @"\'\:\!]+";
    			return Regex.Replace(Path.GetFileNameWithoutExtension(absoluteUri.LocalPath), repl, @"_");
    		}
    	}
    }
