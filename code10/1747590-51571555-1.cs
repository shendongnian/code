    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdetityUser> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result==null)
            {
                IdetityUseruser = new IdetityUser
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com"
                };
                IdentityResult result = userManager.CreateAsync(user, "PassordHere").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }       
        }   
    }
