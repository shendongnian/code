    public class VersionNumber : IComparable {
    
        public int Major    { get; set; }
        public int Minor    { get; set; }
        public int Revision { get; set; }
    
        // Converts string to VersionNumber object
        public static VersionNumber Parse(string s) {
            if (string.IsNullOrWhiteSpace(s)) {
                throw new ArgumentNullException(nameof(s));
            }
    
            var parts = s.Split(new [] {'.'});
            if (parts.Count() != 3) {
                throw new ArgumentException("Input string must be in format 'X.Y.ZZZZZ'.");
            }
           
            try {
                Major = int.Parse(parts[0]);
                Minor = int.Parse(parts[1]);
                Revision = int.Parse(parts[2]);
            }
            catch (FormatException) {
                throw new ArgumentException("Input string must be in format 'X.Y.ZZZZZ', with X, Y, Z integers.");
            }
        }
        // Compares two VersionNumbers
        public int CompareTo(object obj) {
            if (obj == null) return 1;
            VersionNumber otherVersion = obj as VersionNumber;
            if (otherVersion == null) {
                throw new ArgumentException($"Object is not a {nameof(VersionNumber)}.");
            }
            // start comparison with Major Version, then Minor, then Revision
            var result = Major.CompareTo(otherVersion.Major);
            if (result == 0) {
                result = Minor.CompareTo(otherVersion.Minor);
            }
            if (result == 0) {
                result = Revision.CompareTo(otherVersion.Revision);
            }
            return result;
        }
    }
