    public class YourControllerNameController : Controller
    {
       public IActionResult YourMethodName()
       {
           var userId =  User.FindFirst(ClaimTypes.NameIdentifier).Value // will give the user's userId
           var userName =  User.FindFirst(ClaimTypes.Name).Value // will give the user's userName
           var userEmail =  User.FindFirst(ClaimTypes.Email).Value // will give the user's Email
       }
    }
