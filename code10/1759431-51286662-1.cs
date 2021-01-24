    public class User {
		public List<UserRole> UserRoles { get; set; }
	}
	public class UserRole {
		public Role Role { get; set; }
	}
	public class Role {
		public List<RolePermission> RolePermissions { get; set; }
	}
	public class RolePermission {
		public Permission Permission { get; set; }
	}
	public class Permission {
		public string MyPermission { get; set; }
	}
