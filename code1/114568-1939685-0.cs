    [TableMapping("Users")]
    public class User : EntityBase
    {
        #region Constructor(s)
        public AppUser()
        {
            BookCollection = new BookCollection();
        }
        #endregion
        #region Properties
        #region Default Properties - Direct Field Mapping using DataFieldMappingAttribute
        private System.Int32 _UserId;
        private System.String _FirstName;
        private System.String _LastName;
        private System.String _UserName;
        private System.Boolean _IsActive;
        [DataFieldMapping("UserID")]
        [DataObjectFieldAttribute(true, true, false)]
        [NotNullOrEmpty(Message = "UserID From Users Table Is Required.")]
        public override int Id
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        [DataFieldMapping("UserName")]
        [Searchable]
        [NotNullOrEmpty(Message = "Username Is Required.")]
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        [DataFieldMapping("FirstName")]
        [Searchable]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        [DataFieldMapping("LastName")]
        [Searchable]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        [DataFieldMapping("IsActive")]
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        #region One-To-Many Mappings
        public BookCollection Books { get; set; }
        #endregion
        #region Derived Properties
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        #endregion
        #endregion
        public override bool Validate()
        {
            bool baseValid = base.Validate();
            bool localValid = Books.Validate();
            return baseValid && localValid;
        }
    }
