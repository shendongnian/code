    public interface ILoginService
    {
       bool Login(string username, string password);
    }
    public class TimeTable
    {
       ILoginService _loginService;
       public TimeTable(ILoginService loginService)
       {
         _loginService = loginService;
       }
       public bool TimeTableLogin(string username, string password)
       {
          return loginService.Login(username, password);
       }
    }
