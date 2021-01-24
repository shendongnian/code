            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.Use(async (context,next) => {
                await next();
                if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                        var result = JsonConvert.SerializeObject(new { error = "Not Support" });
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync(result);
                }
            });
