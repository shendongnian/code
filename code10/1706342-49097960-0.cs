    namespace User.Model
    {
        public partial class User
        {
            public string FullName
            {
                get
                {
                    return (this.firstName + " " + this.lastName;
                }
                protected set { }
            }
        }
    }
