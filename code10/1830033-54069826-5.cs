    private async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
        var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        IdentityResult roleResult;
        //Adding Admin Role
        var roleCheck = await RoleManager.RoleExistsAsync("Admin");
        if (!roleCheck)
        {
            IdentityRole adminRole = new IdentityRole("Admin");
            //create the roles and seed them to the database
            roleResult = await RoleManager.CreateAsync(adminRole);
            RoleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.AuthorizationDecision, "edit.post")).Wait();
            RoleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.AuthorizationDecision, "delete.post")).Wait();
            ApplicationUser user = new ApplicationUser { UserName = "v-nany@hotmail.com", Email = "v-nany@hotmail.com" };
            UserManager.CreateAsync(user, "xxxxxx").Wait();
            await UserManager.AddToRoleAsync(user, "Admin");
        }
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env ,IServiceProvider serviceProvider)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        app.UseAuthentication();
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
        CreateUserRoles(serviceProvider).Wait();
    }
