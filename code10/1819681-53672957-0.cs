    public class ApplicationUser: IdentityUser
    {
       //whatever additional properties you need here
       public DateTime Birthdate {get; set; }
       public string Country {get; set; }
    }
