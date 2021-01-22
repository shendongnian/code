       public class AjaxResponse
        {            
            public string Message { get; set; }
            public string FullError { get; set; }
            public AjaxResponse() { }
            public AjaxResponse(Exception e) 
            {
                Message = e.Message;
                FullError = e.ToString();
            }
        }
        public class AjaxResponse<T> : AjaxResponse
        {
            public T Response { get; set; }
            public AjaxResponse() { }
            public AjaxResponse(Exception e) : base(e) { }
            public AjaxResponse(T resp)
            {
                Response = resp;
            }           
        }
