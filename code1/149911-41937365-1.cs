     public void RegisterActivity()
        {
            if ((Response.ContentType == "text/html") && (Request.IsAuthenticated))
            {
                string userName = Page.User.Identity.Name;
                
                UserManager userManager = new UserManager();
                AppUser appUser = userManager.FindByName(userName);
                appUser.LastActivityDate = DateTime.UtcNow;
                userManager.Update(appUser);
            }
        }
