        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                foreach (byte b in _key)
                    result = (result*31) ^ b;
                return result;
            }
        }
