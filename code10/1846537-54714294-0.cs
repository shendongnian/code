    public readonly struct Key
    {
        public Key(string key1, string key2, string key3) : this()
        {
            Key1 = key1?.Trim() ?? "";
            Key2 = key2?.Trim() ?? "";
            Key3 = key3?.Trim() ?? "";
        }
        public string Key1 { get; }
        public string Key2 { get; }
        public string Key3 { get; }
        public override bool Equals(object obj)
        {
            if (!(obj is Key)) {
                return false;
            }
            var key = (Key)obj;
            return
                String.Equals(Key1, key.Key1, StringComparison.CurrentCultureIgnoreCase) &&
                String.Equals(Key2, key.Key2, StringComparison.CurrentCultureIgnoreCase) &&
                String.Equals(Key3, key.Key3, StringComparison.CurrentCultureIgnoreCase);
        }
        public override int GetHashCode()
        {
            int hashCode = -2131266610;
            unchecked {
                hashCode = hashCode * -1521134295 + StringComparer.CurrentCultureIgnoreCase.GetHashCode(Key1);
                hashCode = hashCode * -1521134295 + StringComparer.CurrentCultureIgnoreCase.GetHashCode(Key2);
                hashCode = hashCode * -1521134295 + StringComparer.CurrentCultureIgnoreCase.GetHashCode(Key3);
            }
            return hashCode;
        }
    }
