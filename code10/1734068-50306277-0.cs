    public class EstablishDepartmentMiddleware
    {
        private RequestDelegate _next;
        public EstablishDepartmentMiddleware(RequestDelegate next)
        {
            this._next = next;            
        }
        public async Task InvokeAsync(HttpContext context, IDepartmentContext departmentContext)
        {            
            await TryGetDepartmentFromBody(context, departmentContext);
            // TryGetFromQuery
            // TryGetFromRoute
            await _next(context);
        }
        private static async Task TryGetDepartmentFromBody(HttpContext context, IDepartmentContext departmentContext)
        {
            using (var sr = new StreamReader(context.Request.Body))
            {
                var bodyText = await sr.ReadToEndAsync();
                var department = JsonConvert.DeserializeObject<Department>(bodyText);
                if (department != null)
                {
                    departmentContext.DepartmentId = department.DepartmentId;
                }
            }
        }
    }
