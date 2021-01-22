        public class ExtJSJsonResult : JsonResult
        {
            public bool success { get; set; }
            public string msg { get; set; }
            
            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null){
                    throw new ArgumentNullException("context");}
    
                HttpResponseBase response = context.HttpContext.Response;
    
                if (!String.IsNullOrEmpty(ContentType))
                {
                    response.ContentType = ContentType;
                }
                else
                {
                    response.ContentType = "application/json";
                }
                if (ContentEncoding != null)
                {
                    response.ContentEncoding = ContentEncoding;
                }
                if (Data != null)
                {
                    Type type = Data.GetType();
                    response.Write(String.Format("{{success: true, msg: \"{0}\", data:", msg));
                    if (type == typeof(DataRow))
                        response.Write(JSonHelper.Serialize(Data, true));
                    else if (type == typeof(DataTable))
                        response.Write(JSonHelper.Serialize(Data, true));
                    else if (type == typeof(DataSet))
                        response.Write(JSonHelper.Serialize(Data, true));
                    else
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        response.Write(serializer.Serialize(Data));
                    }
                    response.Write("}");
                }
            }
        }
