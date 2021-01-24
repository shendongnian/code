    using ITKA.Data.Entities;
    //or just use ITKA.Data.Entities.Company
    namespace ITKA.Domain.Classes 
    {
        public class AppUser : IdentityUser
        {
            ....
            public virtual Company Company { get; set; }
            ....
        }
    }
