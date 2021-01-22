        public int getHashCode()
        {
            PropertyInfo[] theProperties = this.GetType().GetProperties();
            int hash = 31;
            foreach (PropertyInfo info in theProperties)
            {
                if (info != null)
                    unchecked
                    {
                        hash = 29 * hash ^ info.GetHashCode();
                    }
            }
            return hash;  
        }
