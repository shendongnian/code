    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public static class EnumExtensions
    {
        public static TEnum ToEnum<TEnum>(this string value) where TEnum : Enum
        {
            var jsonString = $"'{value.ToLower()}'";
            return JsonConvert.DeserializeObject<TEnum>(jsonString, new StringEnumConverter());
        }
        public static bool EqualsTo<TEnum>(this string strA, TEnum enumB) where TEnum : Enum
        {
            TEnum enumA;
            try
            {
                enumA = strA.ToEnum<TEnum>();
            }
            catch
            {
                return false;
            }
            return enumA.Equals(enumB);
        }
    }
