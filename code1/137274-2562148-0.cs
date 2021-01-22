	public class XmlResult : ActionResult {
		public XmlResult(object anObject) {
			Object = anObject;
		}
		public object Object { get; set; }
		public override void ExecuteResult(ControllerContext aContext) {
			if (aContext == null) throw new Exception("Context cannot be null");
			var response = aContext.HttpContext.Response;
			response.ContentType = "application/xml";
			SerializeObjectOn(Object, response.OutputStream);
		}
		private void SerializeObjectOn(object anObject, Stream aStream) {
			var serializer = new XmlSerializer(anObject.GetType());
			serializer.Serialize(aStream, anObject);
		}
	}
	public class MyController : Controller {
		public ActionResult Index() {
			return  new XmlResult(object);
		}
	}
