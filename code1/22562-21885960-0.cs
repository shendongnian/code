            internal static bool IsFileRemote(string path)
        {
                if (String.IsNullOrEmpty(path))
                {
                    return false;
                }
                if (new Uri(path).IsUnc)
                {
                    return true;
                }
                if (new DriveInfo(path).DriveType == DriveType.Network)
                {
                    return true;
                }
                return false;
        }
