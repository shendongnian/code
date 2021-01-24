      public class ExceptionHelper : IExceptionHelper
    {
      private IJwtHelper _jwtHelper;
      public ExceptionHelper(IJwtHelper jwtHelper)
    {
        _jwtHelper = jwtHelper;
    }
        public async Task AddApplicationError(this HttpResponse response)
        {
            Log log = new Log();
            log.UserId = _jwtHelper.GetValueFromToken(token, "UserId");??????
            
        }
    }
    public interface IExceptionHelper
    {
    Task AddApplicationError( HttpResponse response);
     }
