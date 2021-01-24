    public class ApiBaseController
    {
        public int GetUserId()
        {
            return (int)HttpContext.Session.GetInt32;
        }
    }
