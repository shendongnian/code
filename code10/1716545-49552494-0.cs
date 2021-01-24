    Windows authentication that uses the local domain user and that is intended for intranet sites.
    
    Example : 
    
    I implemented a TestAuthentication method/action with a fixed route path. For the demo I do not include Authorize attributes yet. The code checks the User property of the ApiController. This contains the same data as Thread.CurrentPrincipal or HttpContext.Current.User. Make sure Anonymous Authentication in IIS is disabled otherwise the Identity.Name will be empty.
    
    
    
    public class WinAuthController : ApiController
    {
        [HttpGet]
        [Route("api/testauthentication")]
        public IHttpActionResult TestAutentication()
        {
            Debug.Write("AuthenticationType:" + User.Identity.AuthenticationType);
            Debug.Write("IsAuthenticated:" + User.Identity.IsAuthenticated);
            Debug.Write("Name:" + User.Identity.Name);
     
            if (User.Identity.IsAuthenticated)
            {
                return Ok("Authenticated: " + User.Identity.Name);
            }
            else
            {
                return BadRequest("Not authenticated");
            }
        }
    }
    
    In Web.config file : 
    
    <system.web>
       <authentication mode="Windows" />
     </system.web> 
    
    In IE you can check the setting with Tools > Internet Options > Advanced and look for a setting Enable Windows Integrated Authentication. When you go to the tab Security and then Intranet and Custom Level, then you will find a setting at the bottom to specify if IE should logon automatically or prompt for the username and password.
    
    [![enter image description here][1]][1]
    [![enter image description here][1]][1]
    
    
      [1]: https://i.stack.imgur.com/z49b4.png
    
    Please visit below link ,it has proper steps to follow for WEP API Windows authentication : 
    http://www.scip.be/index.php?Page=ArticlesNET38&Lang=EN
