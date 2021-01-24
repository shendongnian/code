            private static void UpdatePermissions(ClientContext clientContext)
        {
            try
            {
                clientContext.Load(clientContext.Web);
                clientContext.Load(clientContext.Web.RoleDefinitions);
                clientContext.ExecuteQuery();
                var roleDefinitions = clientContext.Web.RoleDefinitions;
                var ownerPermissions = roleDefinitions.GetByName("Owner");
                clientContext.Load(ownerPermissions);
                clientContext.ExecuteQuery();
                var basePermissions = CopyBasePermissionLevel(ownerPermissions.BasePermissions);
                basePermissions.Set(PermissionKind.DeleteVersions);
                basePermissions.Set(PermissionKind.UseClientIntegration);
                basePermissions.Set(PermissionKind.UseRemoteAPIs);
                ownerPermissions.BasePermissions = basePermissions;
                //clientContext.Load(ownerPermissions);
                ownerPermissions.Update();
                clientContext.ExecuteQuery();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UpdatePermissions " + e.Message);
                WriteLog(fileName, "UpdatePermissions " + e.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static BasePermissions CopyBasePermissionLevel(BasePermissions basePermission)
        {
            var copiedPermissions = new BasePermissions();
            foreach (var permission in Enum.GetValues(typeof(PermissionKind)))
            {
                if (basePermission.Has((PermissionKind) permission))
                {
                    copiedPermissions.Set((PermissionKind)permission);
                }
            }
            return copiedPermissions;
        }
