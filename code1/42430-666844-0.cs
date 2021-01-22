        public override int GetHashCode()
        {
            return str1.GetHashCode() ^ str2.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!obj is KeyObj)
            {
                return false;
            }
            KeyObj key = (KeyObj)obj;
            return this.str1.Equals(key.str1) && this.str2.Equals(key.str2);
        }
