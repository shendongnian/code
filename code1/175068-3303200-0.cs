    public enum StatusCode
    {
        Success = 1,
        Error =2
    }
    
    public class UserGvUtil
    {
        public StatusCode getStatusAfterDelete(GridView GridView1, string Msg) 
        {
            try
            {
                DeleteSelectedUsersAndProfiles(GridView1, Msg);
                Return StatusCode.Success;
            }
            catch (Exception ex)
            {
                UserGvUtil.ExceptionErrorMessage(Msg, ex);
                Return StatusCode.Error;
            }
        }
    
    //your other methods here
    }
