    public class DbInitializer {
        public static async Task Initialize(IApplicationBuilder app) {
            //... ...
            if (! await roleManager.RoleExistsAsync("Administrator")) {
                IdRoleResult = await roleManager.CreateAsync(new IdentityRole("Administrator"));
                if (!IdRoleResult.Succeeded)
                    throw new Exception("Administrator role wasnt created.");
            }
            if (! await roleManager.RoleExistsAsync("User")) {
                IdUserResult = await roleManager.CreateAsync(new IdentityRole("User"));
                if (!IdUserResult.Succeeded)
                    throw new Exception("User role wasnt created.");
            }
            //If there are no users, create a test user and test admin. Assign roles
            if (!context.Users.Any()) {
                var user = new ApplicationUser {
                    UserName = "user@user.com",
                    UserFirstName = "Firstname",
                    UserLastName = "LastName",
                    Email = "user@user.com",
                    UserSchool = "University of Maryland",
                    RefMedSchoolId = 1,
                    EmailConfirmed = false,
                    LockoutEnabled = false
                };
                var resultUser = await userManager.CreateAsync(user, "Password123!");
                var resultUserRole = await userManager.AddToRoleAsync(user, "User");
                var admin = new ApplicationUser {
                    UserName = "admin@admin.com",
                    UserFirstName = "Firstname",
                    UserLastName = "LastName",
                    Email = "admin@admin.com",
                    UserSchool = "University of Maryland",
                    RefMedSchoolId = 1,
                    EmailConfirmed = false,
                    LockoutEnabled = false
                };
                var resultAdmin = await userManager.CreateAsync(admin, "Password123!");
                var resultAdministratorRole = await userManager.AddToRoleAsync(admin, "Administrator");
                
                //...
            }
        }
    }
