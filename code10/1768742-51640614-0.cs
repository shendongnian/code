    public class ApplicationUser : IdentityUser<Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
        {
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                return userIdentity;
            }
    
            public ApplicationUser()
            {
               Brands = new Collection<Brand>();
            }
    
            public ICollection<Brand> Brands { get; set; }
        }
    
    public class Brand
    {
        [Key]
        public int Id { get; set; }
    
        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }
    
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
    
        public virtual ApplicationUser Author { get; set; }
    
        public virtual List<CarModel> CarsModel { get; set; }
    }
     public class CarModel
    {
        [Key]
        public int Id { get; set; }
    
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
    
        [ForeignKey("Brand")]
        public string BrandId { get; set; }
    }
    }
