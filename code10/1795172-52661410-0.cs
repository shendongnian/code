    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class RoleManagement
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Group", IsNullable = false)]
        public List<RoleManagementGroup> Permissions { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("RolePermission", IsNullable = false)]
        public List<RoleManagementRolePermission> RolePermissions { get; set; }
        /// <remarks/>
        public RoleManagementRoles Roles { get; set; }
    }
    /// <remarks/>
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RoleManagementGroup
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Permission")]
        public List<RoleManagementGroupPermission> Permission { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
    }
    /// <remarks/>
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RoleManagementGroupPermission
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ID { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
    }
    /// <remarks/>
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RoleManagementRolePermission
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte RedmineId { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte PermissionID { get; set; }
    }
    /// <remarks/>
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RoleManagementRoles
    {
        /// <remarks/>
        public RoleManagementRolesRole Role { get; set; }
    }
    /// <remarks/>
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RoleManagementRolesRole
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte RedmineId { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte TestlinkId { get; set; }
    }
