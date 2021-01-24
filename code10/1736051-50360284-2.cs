    [CustomAuthFilter] //Secure all methods in the class
    public class SecureApiController
    {
        public ActionResult SecuredApiCall()
        {
            return Foo();
        }
        public ActionResult AnotherSecuredCall()
        {
            return Bar();
        }
        [AllowAnonymous]
        public ActionResult UnsecuredApiCall()
        {
            return UnsecureFoo();
        }
    }
