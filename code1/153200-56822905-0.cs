using System;
namespace EnumTest
{
    public static class EnumExtensions
    {
        #region Get enum from Attribute
        /// <summary>
        /// Searches the enum element which has a [attributeType] attribute with a attributePropertyName equivalent to searchValue.
        /// Throws exception, if there is no enum element found which has a [attributeType] attribute with a attributePropertyName equivalent to searchValue.
        /// </summary>
        /// <param name="attributeType">the type of the attribute. e.g. typeof(System.ComponentModel.DescriptionAttribute)</param>
        /// <param name="attributePropertyName">the property of the attribute to search. At DescriptionAttribute, this is "Description"</param>
        /// <param name="searchValue">the value to search</param>
        public static TEnum FromAttributeValueToEnum<TEnum>(Type attributeType, string attributePropertyName, object searchValue)
        where TEnum : struct, Enum
        {
            TEnum? result = FromAttributeValueToNullableEnum<TEnum>(attributeType, attributePropertyName, searchValue);
            if (result.HasValue)
            {
                return result.Value;
            }
            Type enumType = typeof(TEnum);
            throw new ArgumentException($"The enum type {enumType.FullName} has no element with a {attributeType.FullName} with {attributePropertyName} property equivalent to '{searchValue}'");
        }
        /// <summary>
        /// Searches the enum element which has a [attributeType] attribute with a attributePropertyName equivalent to searchValue.
        /// Returns fallBackValue, if there is no enum element found which has a [attributeType] attribute with a attributePropertyName equivalent to searchValue.
        /// </summary>
        /// <param name="attributeType">the type of the attribute. e.g. typeof(System.ComponentModel.DescriptionAttribute)</param>
        /// <param name="attributePropertyName">the property of the attribute to search. At DescriptionAttribute, this is "Description"</param>
        /// <param name="searchValue">the value to search</param> 
        public static TEnum FromAttributeValueToEnum<TEnum>(Type attributeType, string attributePropertyName, object searchValue, TEnum fallBackValue)
        where TEnum : struct, Enum
        {
            TEnum? result = FromAttributeValueToNullableEnum<TEnum>(attributeType, attributePropertyName, searchValue);
            if (result.HasValue)
            {
                return result.Value;
            }
            return fallBackValue;
        }
        /// <summary>
        /// Searches the enum element which has a [attributeType] attribute with a attributePropertyName equivalent to searchValue.
        /// Returns null, if there is no enum element found which has a [attributeType] attribute with a attributePropertyName equivalent to searchValue.
        /// </summary>
        /// <param name="attributeType">the type of the attribute. e.g. typeof(System.ComponentModel.DescriptionAttribute)</param>
        /// <param name="attributePropertyName">the property of the attribute to search. At DescriptionAttribute, this is "Description"</param>
        /// <param name="searchValue">the value to search</param> 
        public static TEnum? FromAttributeValueToNullableEnum<TEnum>(Type attributeType, string attributePropertyName, object searchValue)
        where TEnum : struct, Enum
        {
            Type enumType = typeof(TEnum);
            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"The type {enumType.FullName} is no Enum!");
            }
            if (attributeType == null)
            {
                throw new ArgumentNullException(nameof(attributeType));
            }
            if (!typeof(Attribute).IsAssignableFrom(attributeType))
            {
                throw new ArgumentException($"The type {attributeType.FullName} is no Attribute!", nameof(attributeType));
            }
            var propertyInfoAttributePropertyName = attributeType.GetProperty(attributePropertyName);
            if (propertyInfoAttributePropertyName == null)
            {
                throw new ArgumentException($"The type {attributeType.FullName} has no (public) property with name {attributePropertyName}", nameof(attributeType));
            }
            foreach (var field in enumType.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, attributeType);
                if (attribute == null)
                {
                    continue;
                }
                object attributePropertyValue = propertyInfoAttributePropertyName.GetValue(attribute);
                if (attributePropertyValue == null)
                {
                    continue;
                }
                if (attributePropertyValue.Equals(searchValue))
                {
                    return (TEnum)field.GetValue(null);
                }
            }
            return null;
        }
        #endregion
    }
}
@RubenHerman's initial post:
Als Beantwoord = EnumExtensions.FromAttributeValueToEnum<Als>(typeof(StringValueAttribute), nameof(StringValueAttribute.Value), "Beantwoord");
**Advanced sample:**
public class IntValueAttribute : Attribute
{
    public IntValueAttribute(int value)
    {
        Value = value;
    }
    public int Value { get; private set; }
}
public enum EnumSample
{
    [Description("Eins")]
    [IntValue(1)]
    One,
    [Description("Zwei")]
    [IntValue(2)]
    Two,
    [Description("Drei")]
    [IntValue(3)]
    Three
}
EnumSample one = EnumExtensions.FromAttributeValueToEnum<EnumSample>(typeof(DescriptionAttribute), nameof(DescriptionAttribute.Description), "Eins");
EnumSample two = EnumExtensions.FromAttributeValueToEnum<EnumSample>(typeof(IntValueAttribute), nameof(IntValueAttribute.Value), 2);
