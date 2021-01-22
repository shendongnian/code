    public class User
        {
            public UserType UserType { get; set; }
    
            [RequiredIf("UserType", UserType.Admin, ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(ResourceString))]
            public string Password
            {
                get;
                set;
            }
        }
