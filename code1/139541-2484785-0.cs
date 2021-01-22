    public class PermissionsAttribute : Attribute {
        private readonly string permissions;
        public string Permissions { get {return permissions;}}
        public PermissionsAttribute(string permissions) {
            this.permissions = permissions;
        }
    }
