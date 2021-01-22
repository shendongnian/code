    public class DCalResult : ActionResult
    {
        private readonly ISomeDCalInterface _dcalObject;
    
        public DCalResult(ISomeDCalInterface dcalObject)
        {
            _dcalObject = dcalObject;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;    
            response.ClearHeaders();
            response.ContentType = "text/calendar";
            response.Write(_dcalObject.ToString());
        }
    }
