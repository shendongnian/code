    public class CustomAuthorizeAttribute : AuthorizeAttribute {
        public bool EmployeeOnly { get; set; }
        private string _company;
    
        public string Company {
            get { return _company; }
            set { _company = value; }
        }
    
    
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            return base.AuthorizeCore(httpContext) && MyAuthorizationCheck(httpContext);
        }
    
        private bool MyAuthorizationCheck(HttpContextBase httpContext) {
            IPrincipal user = httpContext.User;
    
            if (EmployeeOnly && !VerifyUserIsEmployee(user)) {
                return false;
            }
    
            if (!String.IsNullOrEmpty(Company) && !VerifyUserIsInCompany(user)) {
                return false;
            }
    
            return true;
        }
    
        private bool VerifyUserIsInCompany(IPrincipal user) {
            // your check here
        }
    
        private bool VerifyUserIsEmployee(IPrincipal user) {
            // your check here
        }
    }
