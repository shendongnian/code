    public class TimeBucketComparer : IComparer, IComparer<string> {
        public static TimeBucketComparer Instance { get; } = new TimeBucketComparer();
        private static readonly Lazy<Dictionary<string, TimeBucket>> _values = new Lazy<Dictionary<string, TimeBucket>>(() => {
            // get all fields and store in dictionary, keyed by description attribute
            return typeof(TimeBucket)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .ToDictionary(c => 
                    c.GetCustomAttribute<DescriptionAttribute>()?.Description ?? c.Name, 
                    c => (TimeBucket) c.GetValue(null));
        });
        private TimeBucketComparer() {
        }
        public int Compare(object x, object y) {
            string xvar = string.Join("", x.ToString().Split(' '));
            string yvar = string.Join("", y.ToString().Split(' '));
            return Compare(xvar, yvar);   
        }
        public int Compare(string x, string y) {
            if (!_values.Value.ContainsKey(x))
            {
                // do something, invalid value
                throw new ArgumentException(nameof(x));
            }
            if (!_values.Value.ContainsKey(y))
            {
                // do something, invalid value
                throw new ArgumentException(nameof(y));
            }
            return _values.Value[x].CompareTo(_values.Value[y]);
        }
    }
