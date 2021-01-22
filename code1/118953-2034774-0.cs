    public static class PermissionFlags {
        public const string Create = "Create";
    }
    [PrincipalPermission(SecurityAction.Demand, Role = PermissionFlags.Create)]
    public void CreateNew() {
        System.Windows.Forms.MessageBox.Show("Created!");
    }
