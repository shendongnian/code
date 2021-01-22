    /// <summary>
    /// Represents User.
    /// </summary>
    [TableMapping("Users", "User", "Users")]
    public class User : EntityBase
    {
        #region Constructor(s)
        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public User()
        {
        }
        #endregion
        #region Properties
        #region Default Properties - Direct Field Mapping using DataFieldMappingAttribute
        /// <summary>
        /// Gets or sets the ID value of the AppUser object.
        /// </summary>
        [DataFieldMapping("UserID")]
        [DataObjectFieldAttribute(true, true, false)]
        [NotNullOrEmpty(Message = "UserID From UserDetails Table Is Required.")]
        public override int Id
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Username value of the User object.
        /// </summary>
        [DataFieldMapping("UserName")]
        [Searchable]
        [NotNullOrEmpty(Message = "Username Is Required.")]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the FirstName value of the AppUser object.
        /// </summary>
        [DataFieldMapping("FirstName")]
        [Searchable]
        public string FirstName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the LastName value of the AppUser object.
        /// </summary>
        [DataFieldMapping("LastName")]
        [Searchable]
        public string LastName
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the WebSite value of the AppUser object.
        /// </summary>
        [DataFieldMapping("WebSite")]
        [ValidURL(Message = "Website is not in Proper Format.")]
        public string WebSite
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the ContactNumber value of the AppUser object.
        /// </summary>
        [DataFieldMapping("ContactNumber")]
        [Searchable]
        public string ContactNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether AppUser Object is active or inactive.
        /// </summary>
        [DataFieldMapping("IsActive")]
        public bool IsActive
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the BirthDate value of the AppUser object.
        /// </summary>
        [DataFieldMapping("BirthDate")]
        public DateTime? BirthDate
        {
            get;
            set;
        }
        #region Derived Properties
        /// <summary>
        /// Gets the full name of the AppUser
        /// </summary>
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
        /// <summary>
        /// Gets the Age value of the AppUser
        /// </summary>
        public int Age
        {
            get { return this.BirthDate.HasValue ? this.BirthDate.Value.AgeInYears() : 0; }
        }
        #endregion
        #endregion
    }
