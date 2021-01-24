    using Microsoft.AspNet.Identity;
    […]
    
    if (User.Identity.GetUserId() == Goals.UserId)
    {
        // show all the logged in user's goal
    }
