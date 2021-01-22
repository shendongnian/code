      public static TEnum ToEnum<TEnum>(object EnumValue, TEnum defaultValue)
        {
            if (!Enum.IsDefined(typeof(TEnum), EnumValue))
            {
                Type enumType = Enum.GetUnderlyingType(typeof(TEnum));
                if ( EnumValue.GetType() == enumType )
                {
                    string name = Enum.GetName(typeof(HLink.ViewModels.ClaimHeaderViewModel.ClaimStatus), EnumValue);
                    if( name != null)
                        return (TEnum)Enum.Parse(typeof(TEnum), name);
                    return defaultValue;
                }
            }
            return (TEnum)Enum.Parse(typeof(TEnum), EnumValue.ToString());
        } 
