        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
            });
        }
        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult VacationBalance()
        {
        return View();
        }
