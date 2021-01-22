         public object BindModel(
            			ControllerContext controllerContext, 
            			ModelBindingContext bindingContext)
            		{  
            			TestIBE.Models.IBERequest _IBERequest;
            			HttpContextBase _httpContext;
            			Dictionary<string, string> _requestData;
            
            
            			_httpContext = controllerContext.HttpContext;
            			_requestData = this.CreateRequestData(_httpContext.Request);
            
            			_IBERequest = new TestIBE.Models.IBERequest(
            				_httpContext.Session.SessionID,
            				_httpContext.Request.UserHostAddress,
            				_httpContext.Request.UserAgent,
            				_httpContext.Request.Url,
            				_requestData);
            
            			return _IBERequest;
            		}
            
            
            		private Dictionary<string, string> CreateRequestData(
            			HttpRequestBase subject)
            		{
            			Dictionary<string, string> _result;
            
            
            			_result = new Dictionary<string, string>();
            			subject.Form.AllKeys.ForEach(key => _result.Add(key, subject.Form[key]));
            			subject.QueryString.AllKeys.ForEach(key => { if (!_result.ContainsKey(key)) { _result.Add(key, subject.QueryString[key]); } });
            
            			return _result;
            		}
    
    
    public class IBEController : Controller
        {
            public ActionResult Landing(
    			[ModelBinder(typeof(TestIBE.Helpers.Binders.IBEModelBinder))] TestIBE.Models.IBERequest IBERequest)
            {
    			// TODO
                return View();
            }
        }
