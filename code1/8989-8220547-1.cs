    namespace Reform.Water.Business.Common
    {
    /// <summary>
    /// Validation Utility
    /// </summary>
    public static class ValidationUtility
    {
        /// <summary>
        /// Data entity validation
        /// </summary>
        /// <param name="data">Data entity object</param>
        /// <returns>return true if the object is valid, otherwise return false</returns>
        public static bool Validate(object data)
        {
            bool result = true;
            PropertyInfo[] properties = data.GetType().GetProperties();
            foreach (PropertyInfo p in properties)
            {
                //Length validatioin
                Attribute attribute = Attribute.GetCustomAttribute(p,typeof(ValidLengthAttribute), false);
                if (attribute != null)
                {
                    ValidLengthAttribute validLengthAttribute = attribute as ValidLengthAttribute;
                    if (validLengthAttribute != null)
                    {
                        int maxLength = validLengthAttribute.MaxLength;
                        int minLength = validLengthAttribute.MinLength;
                        string stringValue = p.GetValue(data, null).ToString();
                        if (stringValue.Length < minLength || stringValue.Length > maxLength)
                        {
                            return false;
                        }
                    }
                }
                //Range validation
                attribute = Attribute.GetCustomAttribute(p,typeof(ValidRangeAttribute), false);
                if (attribute != null)
                {
                    ValidRangeAttribute validRangeAttribute = attribute as ValidRangeAttribute;
                    if (validRangeAttribute != null)
                    {
                        decimal maxValue = decimal.MaxValue;
                        decimal minValue = decimal.MinValue;
                        decimal.TryParse(validRangeAttribute.MaxValueString, out maxValue);
                        decimal.TryParse(validRangeAttribute.MinValueString, out minValue);
                        decimal decimalValue = 0;
                        decimal.TryParse(p.GetValue(data, null).ToString(), out decimalValue);
                        if (decimalValue < minValue || decimalValue > maxValue)
                        {
                            return false;
                        }
                    }
                }
                //Regex validation
                attribute = Attribute.GetCustomAttribute(p,typeof(ValidRegExAttribute), false);
                if (attribute != null)
                {
                    ValidRegExAttribute validRegExAttribute = attribute as ValidRegExAttribute;
                    if (validRegExAttribute != null)
                    {
                        string objectStringValue = p.GetValue(data, null).ToString();
                        string regExString = validRegExAttribute.RegExString;
                        Regex regEx = new Regex(regExString);
                        if (regEx.Match(objectStringValue) == null)
                        {
                            return false;
                        }
                    }
                }
                //Required field validation
                attribute = Attribute.GetCustomAttribute(p,typeof(ValidRequiredAttribute), false);
                if (attribute != null)
                {
                    ValidRequiredAttribute validRequiredAttribute = attribute as ValidRequiredAttribute;
                    if (validRequiredAttribute != null)
                    {
                        object requiredPropertyValue = p.GetValue(data, null);
                        if (requiredPropertyValue == null || string.IsNullOrEmpty(requiredPropertyValue.ToString()))
                        {
                            return false;
                        }
                    }
                }
            }
            return result;
        }
    }
}
