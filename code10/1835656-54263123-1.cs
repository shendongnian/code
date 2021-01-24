        public class CallbackJsonResult : JsonNetResult
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CallbackJsonResult"/> class.
            /// </summary>
            /// <param name="statusCode">The status code.</param>
            public CallbackJsonResult(HttpStatusCode statusCode)
            {
                this.Initialize(statusCode, null, null);
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="CallbackJsonResult"/> class.
            /// </summary>
            /// <param name="statusCode">The status code.</param>
            /// <param name="description">The description.</param>
            public CallbackJsonResult(HttpStatusCode statusCode, string description)
            {
                this.Initialize(statusCode, description, null);
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="CallbackJsonResult"/> class.
            /// </summary>
            /// <param name="statusCode">The status code.</param>
            /// <param name="data">The callback result data.</param>
            public CallbackJsonResult(object data, HttpStatusCode statusCode = HttpStatusCode.OK)
            {
                this.ContentType = null;
                this.Initialize(statusCode, null, data);
            }
    
    
    
            /// <summary>
            /// Initializes a new instance of the <see cref="CallbackJsonResult"/> class.
            /// </summary>
            /// <param name="statusCode">The status code.</param>
            /// <param name="description">The description.</param>
            /// <param name="data">The callback result data.</param>
            public CallbackJsonResult(HttpStatusCode statusCode, string description, object data)
            {
                this.Initialize(statusCode, description, data);
            }
    
            /// <summary>
            /// Initializes this instance.
            /// </summary>
            /// <param name="statusCode">The status code.</param>
            /// <param name="description">The description.</param>
            /// <param name="data">The callback result data.</param>
            private void Initialize(HttpStatusCode statusCode, string description, object data)
            {
                Data = new JsonData() { Success = statusCode == HttpStatusCode.OK, Status = (int)statusCode, Description = description, Data = data };
            }
        }
    }
