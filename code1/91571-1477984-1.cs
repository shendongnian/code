    public class UserIDParameter : Parameter
    {
        public UserIDParameter()
        {
            this.Name = "user_id";
            this.DbType = System.Data.DbType.Int32;
        }
        protected override object Evaluate(System.Web.HttpContext context, System.Web.UI.Control control)
        {
            return GetMyCurrentUserID();
        }
    }
