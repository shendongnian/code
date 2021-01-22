        public static int GetEnumValue(string name, Type enumType)
        {
           int result = -1;
   
           foreach (var item in Enum.GetValues(enumType))
           {
               if (item.ToString() == name)
               {
                   result = (int) item;
                   break;
               }
           }
           return result;
        }
        public static string GetEnumValue(int value, Type enumType)
        {
            string result = null;
            foreach (var item in Enum.GetValues(enumType))
            {
                if ((int)item  == value)
                {
                    result = item.ToString();
                    break;
                }
            }
            return result;
        }
