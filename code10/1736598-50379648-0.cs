    public interface IPermissionsChecker
    {
        bool UserHasPermissions( // whatever parameters you need );
    }
    
    public class PermissionsChecker : IPermissionsChecker
    {
        public override bool UserHasPermissions( // same params as above)
        {
            // logic
        }
    }
