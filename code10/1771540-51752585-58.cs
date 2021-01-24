        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeOnly", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                       //Here you can get many resouces from context, i get a claim here for example
                       var yourvalue = context.User.Claims.FirstOrDefault(x => x.Type == "yourType")?.Value;
                       //here you can access DB or any other API to do anything if you don't mind performance issues.
                       var user = new DefaultContext().AspNetUsers.FirstOrDefaultAsync(x =>
                                                    x.UserName == yourvalue);
                       //return a boolen to end validation.
                       return user != null;
                   });
               });
           });
        }
        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult VacationBalance()
        {
           return View();
        }
