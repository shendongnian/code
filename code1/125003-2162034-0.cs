    public static class ObjectExtensions
    {
        public static string ToCustomString(this object instance)
        {
            return instance.ToString() + "whatever";
        }
    }
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object test = 3333;
            Response.Write(test.ToCustomString());
        }
    }
