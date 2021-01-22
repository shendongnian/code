        public static bool GetBoolean(string boolStr)
        {
            bool bVal = default(bool);
            try
            {
                bVal = Convert.ToBoolean(boolStr);
            }
            catch (Exception) {
                bVal = default(bool);
            }
            return bVal;
        }
