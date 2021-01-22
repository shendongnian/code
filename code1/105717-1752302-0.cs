    public class KeyModifierSet
    {
        internal readonly HashSet<Key> Keys = new HashSet<Key>();
        internal readonly HashSet<ModifierKeys> MKeys = new HashSet<ModifierKeys>();
        public override int GetHashCode()
        {
            int hash = Keys.Count + MKeys.Count;
            foreach (var t in Keys)
            {
                hash *= 17;
                hash = hash + t.GetHashCode();
            }
            foreach (var t in MKeys)
            {
                hash *= 19;
                hash = hash + t.GetHashCode();
            }
            return hash;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as KeyModifierSet);
        }
        public bool Equals(KeyModifierSet other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;
            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;
            // Check for same Id and same Values
            return Keys.SetEquals(other.Keys) && MKeys.SetEquals(other.MKeys);
        }
        public KeyModifierSet(ModifierKeys mKey)
        {
            MKeys.Add(mKey);
        }
        public KeyModifierSet(Key key)
        {
            Keys.Add(key);
        }
        public KeyModifierSet(Key key, ModifierKeys mKey)
        {
            Keys.Add(key);
            MKeys.Add(mKey);
        }
        public KeyModifierSet Add(Key key)
        {
            Keys.Add(key);
            return this;
        }
        public KeyModifierSet Add(ModifierKeys key)
        {
            MKeys.Add(key);
            return this;
        }
    }
