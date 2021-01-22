     public bool IsLocked(DirectoryEntry entryPC)
        {
            if (entryPC.NativeGuid == null)
            {
                return false;
            }
            int flags = (int)entryPC.Properties["UserFlags"].Value;
            bool check = Convert.ToBoolean(flags & 0x0010);
            if (Convert.ToBoolean(flags & 0x0010))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
