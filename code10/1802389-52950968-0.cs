      private async Task HandleExceptionAsync(HttpContext context, Exception exception, IUnitOfWork unitOfWork, IJwtHelper jwtHelper)
        {
            Log log = new Log();
            log.UserIp = jwtHelper.GetValueFromToken("UserIp");
    
            unitOfWork.LogRepo.AddOrUpdate(log);
            await unitOfWork.CompleteAsync();
            await context.Response.WriteAsync(exception.Message);
            
            return ;
        }
