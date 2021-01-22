    [MetadataTypeAttribute(typeof(UserPermissionMembers.UserPermissionMembersMetadata))]
    public partial class UserPermissionMembers
    {
    	internal sealed class UserPermissionMembersMetadata
    	{
    		private UserPermissionMembersMetadata()
    		{}
    
    		public int ID;
    		public UserRole UserRole;
    
    		[Include]
    		[Association("UserPermission", "fkPermissionID", "PermissionID", IsForeignKey = true)]
    		public UserPermission UserPermission;
    	}
    }
