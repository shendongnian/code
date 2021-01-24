    using ITKA.Domain.Classes;
    //or just use ITKA.Domain.Classes.AppUser;
    namespace ITKA.Web 
    {
        public class AppUserManager : UserManager<AppUser>
        {
            ....
            public virtual Company Company { get; set; }
            ....
        }
    }
