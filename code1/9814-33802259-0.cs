    /// <summary>
    /// Formats a string with named format items given a template dictionary of the items values to use.
    /// </summary>
    public class StringTemplateFormatter
    {
        private readonly IFormatProvider _formatProvider;
    
        /// <summary>
        /// Constructs the formatter with the specified <see cref="IFormatProvider"/>.
        /// This is defaulted to <see cref="CultureInfo.CurrentCulture">CultureInfo.CurrentCulture</see> if none is provided.
        /// </summary>
        /// <param name="formatProvider"></param>
        public StringTemplateFormatter(IFormatProvider formatProvider = null)
        {
            _formatProvider = formatProvider ?? CultureInfo.CurrentCulture;
        }
    
        /// <summary>
        /// Formats a string with named format items given a template dictionary of the items values to use.
        /// </summary>
        /// <param name="text">The text template</param>
        /// <param name="templateValues">The named values to use as replacements in the formatted string.</param>
        /// <returns>The resultant text string with the template values replaced.</returns>
        public string FormatTemplate(string text, Dictionary<string, object> templateValues)
        {
            var formattableString = text;
            var values = new List<object>();
            foreach (KeyValuePair<string, object> value in templateValues)
            {
                var index = values.Count;
                formattableString = ReplaceFormattableItem(formattableString, value.Key, index);
                values.Add(value.Value);
            }
            return String.Format(_formatProvider, formattableString, values.ToArray());
        }
    
        /// <summary>
        /// Convert named string template item to numbered string template item that can be accepted by <see cref="string.Format(string,object[])">String.Format</see>
        /// </summary>
        /// <param name="formattableString">The string containing the named format item</param>
        /// <param name="itemName">The name of the format item</param>
        /// <param name="index">The index to use for the item value</param>
        /// <returns>The formattable string with the named item substituted with the numbered format item.</returns>
        private static string ReplaceFormattableItem(string formattableString, string itemName, int index)
        {
            return formattableString
                .Replace("{" + itemName + "}", "{" + index + "}")
                .Replace("{" + itemName + ",", "{" + index + ",")
                .Replace("{" + itemName + ":", "{" + index + ":");
        }
    }
