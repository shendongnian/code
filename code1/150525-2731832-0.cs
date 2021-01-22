        private string CreateRowFilter(string remoteFilePattern)
        {
            string[] pattern = remoteFilePattern.Split(new char[] { '*', '%' });
            int length = pattern.GetUpperBound(0);
            if (length == 0)
            {
                return String.Format("Name = '{0}'", pattern[0]);
            }
            StringBuilder fileter = new StringBuilder(
                     String.Format("Name LIKE '{0}*' ", pattern[0]));
            for (int segment = 1; segment < length; segment++)
            {
                fileter.Append(
                     String.Format("AND Name LIKE '*{0}*' ", pattern[segment]));
            }
            if(String.IsNullOrEmpty(pattern[length]) == false)
            {
                fileter.Append(
                     String.Format("AND Name LIKE '*{0}' ", pattern[length]));
            }
            return fileter.ToString();
        }
