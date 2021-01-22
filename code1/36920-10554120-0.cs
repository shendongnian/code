    public class Versioning : IComparable {
        string _version;
        int _major;
        public int Major { 
            get { return (_major); } 
            set { _major = value; } 
        }
        int _minor;
        public int Minor {
            get { return (_minor); }
            set { _minor = value; }
        }
        int _beta;
        public int Beta {
            get { return (_beta); }
            set { _beta = value; }
        }
        int _alpha;
        public int Alpha {
            get { return (_alpha); }
            set { _alpha = value; }
        }
        public Versioning(string version) {
            _version = version;
            var splitVersion = SplitVersion();
            if (splitVersion.Length < 4) {
                Major = Minor = Beta = Alpha = 0;
            }
            if (!int.TryParse(splitVersion[0], out _major)) _major = 0;
            if (!int.TryParse(splitVersion[1], out _minor)) _minor = 0;
            if (!int.TryParse(splitVersion[2], out _beta)) _beta = 0;
            if (!int.TryParse(splitVersion[3], out _alpha)) _alpha = 0;
        }
        
        string[] SplitVersion() {
            return (_version.Split('.'));
        }
        int GetCompareTo(Versioning versioning) {
            var greater = -1;
            var equal = 0;
            var less = 1;
            if (Major > versioning.Major) return (greater);
            if (Major < versioning.Major) return (less);
            if (Minor > versioning.Minor) return (greater);
            if (Minor < versioning.Minor) return (less);
            if (Beta > versioning.Beta) return (greater);
            if (Beta < versioning.Beta) return (less);
            if (Alpha > versioning.Alpha) return (greater);
            if (Alpha < versioning.Alpha) return (less);
            return (equal);
        }
        public int CompareTo(Versioning versioning) {
            return (GetCompareTo(versioning));
        }
        public override string ToString() {
            return (_version);
        }
        public int CompareTo(object obj) {
            if (obj == null) return (1);
            return (GetCompareTo((Versioning)obj));
        }
    }
