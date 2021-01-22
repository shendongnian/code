        public bool Equals(FileInfo x, FileInfo y)
        {
            if (x == y)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
