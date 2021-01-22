        public static T IsNull<T>(this T DefaultValue, T InsteadValue)
        {
            object obj="kk";
            if((object) DefaultValue == DBNull.Value)
            {
                obj = null;
            }
            if (obj==null || DefaultValue==null || DefaultValue.ToString()=="")
            {
                return InsteadValue;
            }
            else
            {
                return DefaultValue;
            }
        }
    //This method can work with DBNull and null value. This method is question's answer
