        public bool Equals(FileInfo x, FileInfo y)
        {
            if (x == y)
            {
                return true;
            }
            if (x == null)
            {
                return y == null;
            }
            if (y == null)
            {
                return false;
            }
            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase) == 0;
        }
