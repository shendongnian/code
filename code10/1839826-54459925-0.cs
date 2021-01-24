        /// <summary>
        /// Parses permission value and return true if appropriate bit is 1.
        /// </summary>
        protected bool IsPermissionTrue(int permissionValue, NodePermissionsEnum permission)
        {
            return ((permissionValue >> Convert.ToInt32(permission)) % 2) == 1;
        }
