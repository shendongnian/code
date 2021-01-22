    public partial class CustomDataContext {
        public static CustomDataContext Create()
        {
             return new CustomDataContext(ConfigurationManager.ConnectionStrings["CustomConnectionString"].ConnectionString);
        }
    }
