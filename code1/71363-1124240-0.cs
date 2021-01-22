    public class StringHelpers
    {
        private static readonly char[] separator = ",".ToCharArray();
        public static bool UserCanAccessThisPage(
            string userAccessGroups, 
            string pageItemAccessGroups)
        {
            return userAccessGroups
                .Split(separator) // split on comma
                .Select(s => s.Trim()) // trim elements
                .Contains(pageItemAccessGroups); // match
        }
    }
