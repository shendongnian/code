    public interface IAuditor {
        IAuditable Stamp(IAuditable model);
    }
    
    public class Auditor : IAuditor {
        private readonly IHttpContextAccessor accessor;
    
        public Auditor(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
    
        public IAuditable Stamp(IAuditable model){            
            model.CreateDate = DateTime.UtcNow;
            model.CreatedBy = accessor.HttpContext.User?.Identity?.Name;
            return model;
        }
    }
