    public class ObjectMother
    {
        [Export]
        public static EditProfile DefaultEditProfile
        {
            get
            {
                var method = ConfigurationManager.AppSettings["method"];
                var version = ConfigurationManager.AppSettings["version"];
                return new EditProfile(method,version);
            }
        }
    }
