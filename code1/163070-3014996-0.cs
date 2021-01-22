            public bool Equals(Key other)
            {
                return this == other;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is Key))
                {
                    return false;
                }
                return this.Equals((Key)obj);
            }
            public static bool operator ==(Key k1, Key k2)
            {
                if (object.ReferenceEquals(k1, k2))
                {
                    return true;
                }
                if ((object)k1 == null || (object)k2 == null)
                {
                    return false;
                }
                return k1.name == k2.name;
            }
            public static bool operator !=(Key k1, Key k2)
            {
                if (object.ReferenceEquals(k1, k2))
                {
                    return false;
                }
                if ((object)k1 == null || (object)k2 == null)
                {
                    return true;
                }
                return k1.name == k2.name;
            }
            public override int GetHashCode()
            {
                return this.name.GetHashCode();
            }
