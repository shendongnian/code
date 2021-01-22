        public int getHashCode()
        {
            PropertyInfo[] theProperties = this.GetType().GetProperties();
            int hash = 31;
            foreach (PropertyInfo info in theProperties)
            {
                if (info != null)
                {
                    var value = info.GetValue(this,null);
                    if(value != null)
                    unchecked
                    {
                        hash = 29 * hash ^ value.GetHashCode();
                    }
                }
            }
            return hash;  
        }
