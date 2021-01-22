    [HandleError]
    public class HomeController : Controller
    {
        public void Index()
        {
            var x = ShowStackFrame();
            Response.Write(x);
        }
        private string ShowStackFrame()
        {
            StringBuilder b = new StringBuilder();
            StackTrace trace = new StackTrace(0);
            foreach (var frame in trace.GetFrames())
            {
                var method = frame.GetMethod();
                b.AppendLine(method.Name + "<br>");
                
                foreach (var param in method.GetParameters())
                {
                    b.AppendLine(param.Name + "<br>");
                }
                b.AppendLine("<hr>");
            }
            return b.ToString() ;
        }
    }
