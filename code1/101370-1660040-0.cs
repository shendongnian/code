    [TableMapping("Users", "User", "Users")]
    public class User : EntityBase
    {
        #region Constructor(s)
        public User()
        {
        }
        #endregion
        #region Properties
        #region Default Properties - Direct Field Mapping using DataFieldMappingAttribute
        private System.Int32 _UserId;
        private System.String _UserName;
        [DataFieldMapping("UserID")]
        [DataObjectFieldAttribute(true, true, false)]
        [NotNullOrEmpty(Message = "UserID Is Required.")]
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
        #endregion
        #region One-To-Many Mappings
        #endregion
        #region Derived Properties
        #endregion
        #endregion
    }
