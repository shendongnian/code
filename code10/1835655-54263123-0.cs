      public class JsonNetResult : ActionResult
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="JsonNetResult"/> class.
            /// </summary>
            public JsonNetResult()
            {
            }
    
            /// <summary>
            /// Gets or sets the content encoding.
            /// </summary>
            /// <value>The content encoding.</value>
            public Encoding ContentEncoding { get; set; }
    
            /// <summary>
            /// Gets or sets the type of the content.
            /// </summary>
            /// <value>The type of the content.</value>
            public string ContentType { get; set; }
    
            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data object.</value>
            public object Data { get; set; }
    
    
            /// <summary>
            /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
            /// </summary>
            /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
    
                HttpResponseBase response = context.HttpContext.Response;
    
                response.ContentType = !String.IsNullOrWhiteSpace(this.ContentType) ? this.ContentType : "application/json";
    
                if (this.ContentEncoding != null)
                {
                    response.ContentEncoding = this.ContentEncoding;
                }
    
    
                if (this.Data != null)
                {
    
                    response.Write(JsonConvert.SerializeObject(this.Data));
    
                }
            }
        }
