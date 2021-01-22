    static class MyExtensions
    {
        public static IEnumerable<MyZone> Enumerate(this MyZoneArray zone)
        {
            for (int i = 0; i < zone.Length; i++)
                yield return zone[i];
        }
        public static IEnumerable<MyVersion> Enumerate(this MyVersionArray version)
        {
            for (int i = 0; i < version.Length; i++)
                yield return version[i]
        }
    }
