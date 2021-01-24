    app.UseExceptionHandler(
             options =>
             {
                 options.Run(
                 async context =>
                 {
                     var ex = context.Features.Get<IExceptionHandlerFeature>();
                     if (ex != null)
                     {
                         try
                         {
                             await System.Threading.Tasks.Task.Run(async () =>
                              {
                                  var builder = new DbContextOptionsBuilder<DBContext>();
                                  builder.UseSqlServer(_config["ConnectionStrings:ContextConnection"]);
                                  var _context = new DBContext(_config, builder.Options, httpContextAccessor);
                                  //Log to DB
                                  await repository.LogError(_context, ex.Error.Message, $"{ex.Error.InnerException?.Message}<br/>{ex.Error.StackTrace}");
                              });
                         }
                         finally
                         {
                             //Optional
                             await repository.SendMailToAdmin(ex.Error.Message, $"{ex.Error.InnerException?.Message}<br/>{ex.Error.StackTrace}");
                         }
                         context.Response.Redirect("/app/Errors/500");
                     }
                 });
             }
            );
