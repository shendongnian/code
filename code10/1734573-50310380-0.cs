                if (existingOrg.Count() > 0)
                {
                    //user.Organization = new Organization();
                    user.OrganizationId = existingOrg.First().Recno;
                }
                else
                {
                    user.Organization = new Organization();
                    user.Organization.OrganizationName = model.Organization;
                }
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CityId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        public int? OrganizationId { get; set; }
    }
