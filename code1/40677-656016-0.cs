        /// <summary>
        /// Returns a valid XPath statement to use for searching attribute values regardless of 's or "s
        /// </summary>
        /// <param name="attributeValue">Attribute value to parse</param>
        /// <returns>Parsed attribute value in concat() if needed</returns>
        public static string GetXpathStringForAttributeValue(string attributeValue)
        {
            bool hasApos = attributeValue.Contains("'");
            bool hasQuote = attributeValue.Contains("\"");
            if (!hasApos)
            {
                return "'" + attributeValue + "'";
            }
            if (!hasQuote)
            {
                return "\"" + attributeValue + "\"";
            }
            StringBuilder result = new StringBuilder("concat(");
            StringBuilder currentArgument = new StringBuilder();
            for (int pos = 0; pos < attributeValue.Length; pos++)
            {
                switch (attributeValue[pos])
                {
                    case '\'':
                        result.Append('\"');
                        result.Append(currentArgument.ToString());
                        result.Append("'\",");
                        currentArgument.Length = 0;
                        break;
                    case '\"':
                        result.Append('\'');
                        result.Append(currentArgument.ToString());
                        result.Append("\"\',");
                        currentArgument.Length = 0;
                        break;
                    default:
                        currentArgument.Append(attributeValue[pos]);
                        break;
                }
            }
            if (currentArgument.Length == 0)
            {
                result[result.Length - 1] = ')';
            }
            else
            {
                result.Append("'");
                result.Append(currentArgument.ToString());
                result.Append("')");
            }
            return result.ToString();
        }
