        public override int GetHashCode()
        {
            int hash = Id;
            if (Values != null)
            {
                hash = (hash * 17) + Values.Length;
                foreach (T t in Values)
                {
                    hash *= 17;
                    if (t != null) hash = hash + t.GetHashCode();
                }
            }
            return hash;
        }
