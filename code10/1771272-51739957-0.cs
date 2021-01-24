    case PermissionStatus.Revoked:
                    if (existingPermission != null)
                    {
                        user.Permissions.Remove(existingPermission);
                        entity.SaveChanges();
                    }
                    break;
