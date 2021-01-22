    public static List<LocalizableEnum<T>> GetEnumList<T>(object excludeMember)
    {
        List<LocalizableEnum<T>> list =null;
        Array listVal = System.Enum.GetValues(typeof(T));
        if (listVal.Length>0)
        {
            string excludedValStr = string.Empty;
            if (excludeMember != null)
                excludedValStr = ((T)excludeMember).ToString();
            list = new List<LocalizableEnum<T>>();
            for (int i = 0; i < listVal.Length; i++)
            {
                T currentVal = (T)listVal.GetValue(i);
                if (excludedValStr != currentVal.ToString())
                {
                    System.Enum enumVal = currentVal as System.Enum;
                    LocalizableEnum<T> enumMember = new LocalizableEnum<T>(currentVal);
                    list.Add(enumMember);
                }
            }
        }
        return list;
    }
