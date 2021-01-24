        public class Key
        {
            public string nameA;
            public string nameB;
            public override bool Equals(object obj)
            {
                return base.Equals(obj as Key);
            }
            protected bool Equals(Key other)
            {
                return string.Equals(nameA, other.nameA) && string.Equals(nameB, other.nameB) ||
                       string.Equals(nameA, other.nameB) && string.Equals(nameB, other.nameA);
            }
            public override int GetHashCode()
            {
                return (nameA?.GetHashCode() ^ nameB?.GetHashCode()) ?? 0;
            }
        }
