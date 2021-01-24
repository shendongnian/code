    /// <summary>
    /// My custom ActionFilter for the LogActionAttribute. This is the class which gets called to complete the implementation of the attribute
    /// </summary>
    public class LogActionFilter : IActionFilter<LogActionAttribute> {
        private readonly IAccountManagementManager _iAccountManagementManager;
        public LogActionFilter(IAccountManagementManager iAccountManagementManager) {
            _iAccountManagementManager = iAccountManagementManager;
        }
        public void OnActionExecuting(LogActionAttribute attribute, ActionExecutingContext context) {
            var fg = _iAccountManagementManager.ReturnApplicationIDAsync();
        }
    }
