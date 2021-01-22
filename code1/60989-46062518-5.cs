    public class DotNetUtils
    {
        public enum DotNetRelease
        {
            NOTFOUND,
            NET45,
            NET451,
            NET452,
            NET46,
            NET461,
            NET462,
            NET47,
            NET471
        }
        
        public static bool IsCompatible(DotNetRelease req = DotNetRelease.NET452)
        {
            DotNetRelease r = GetRelease();
            if (r < req)
            {
                MessageBox.Show(String.Format("This this application requires {0} or greater.", req.ToString()));
                return false;
            }
            return true;
        }
        public static DotNetRelease GetRelease(int release = default(int))
        {
            int r = release != default(int) ? release : GetVersion();
            if (r >= 461308) return DotNetRelease.NET471;
            if (r >= 460798) return DotNetRelease.NET47;
            if (r >= 394802) return DotNetRelease.NET462;
            if (r >= 394254) return DotNetRelease.NET461;
            if (r >= 393295) return DotNetRelease.NET46;
            if (r >= 379893) return DotNetRelease.NET452;
            if (r >= 378675) return DotNetRelease.NET451;
            if (r >= 378389) return DotNetRelease.NET45;
            return DotNetRelease.NOTFOUND;
        }
        public static int GetVersion()
        {
            int release = 0;
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                .OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                release = Convert.ToInt32(key.GetValue("Release"));
            }
            return release;
        }
    }
