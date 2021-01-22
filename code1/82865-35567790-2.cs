    public static class StringExtension {
        /// <summary>
        /// Extension method that replaces keys in a string with the values of matching object properties.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo} and {foo:SomeFormat}.</param>
        /// <param name="injectionObject">The object whose properties should be injected in the string</param>
        /// <returns>A version of the formatString string with keys replaced by (formatted) key values.</returns>
        public static string FormatWith(this string formatString, object injectionObject) {
            return formatString.FormatWith(GetPropertiesDictionary(injectionObject));
        }
        /// <summary>
        /// Extension method that replaces keys in a string with the values of matching dictionary entries.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo} and {foo:SomeFormat}.</param>
        /// <param name="dictionary">An <see cref="IDictionary"/> with keys and values to inject into the string</param>
        /// <returns>A version of the formatString string with dictionary keys replaced by (formatted) key values.</returns>
        public static string FormatWith(this string formatString, IDictionary<string, object> dictionary) {
            char openBraceChar = '{';
            char closeBraceChar = '}';
            return FormatWith(formatString, dictionary, openBraceChar, closeBraceChar);
        }
            /// <summary>
            /// Extension method that replaces keys in a string with the values of matching dictionary entries.
            /// </summary>
            /// <param name="formatString">The format string, containing keys like {foo} and {foo:SomeFormat}.</param>
            /// <param name="dictionary">An <see cref="IDictionary"/> with keys and values to inject into the string</param>
            /// <returns>A version of the formatString string with dictionary keys replaced by (formatted) key values.</returns>
        public static string FormatWith(this string formatString, IDictionary<string, object> dictionary, char openBraceChar, char closeBraceChar) {
            string result = formatString;
            if (dictionary == null || formatString == null)
                return result;
            // start the state machine!
            // ballpark output string as two times the length of the input string for performance (avoids reallocating the buffer as often).
            StringBuilder outputString = new StringBuilder(formatString.Length * 2);
            StringBuilder currentKey = new StringBuilder();
            bool insideBraces = false;
            int index = 0;
            while (index < formatString.Length) {
                if (!insideBraces) {
                    // currently not inside a pair of braces in the format string
                    if (formatString[index] == openBraceChar) {
                        // check if the brace is escaped
                        if (index < formatString.Length - 1 && formatString[index + 1] == openBraceChar) {
                            // add a brace to the output string
                            outputString.Append(openBraceChar);
                            // skip over braces
                            index += 2;
                            continue;
                        }
                        else {
                            // not an escaped brace, set state to inside brace
                            insideBraces = true;
                            index++;
                            continue;
                        }
                    }
                    else if (formatString[index] == closeBraceChar) {
                        // handle case where closing brace is encountered outside braces
                        if (index < formatString.Length - 1 && formatString[index + 1] == closeBraceChar) {
                            // this is an escaped closing brace, this is okay
                            // add a closing brace to the output string
                            outputString.Append(closeBraceChar);
                            // skip over braces
                            index += 2;
                            continue;
                        }
                        else {
                            // this is an unescaped closing brace outside of braces.
                            // throw a format exception
                            throw new FormatException($"Unmatched closing brace at position {index}");
                        }
                    }
                    else {
                        // the character has no special meaning, add it to the output string
                        outputString.Append(formatString[index]);
                        // move onto next character
                        index++;
                        continue;
                    }
                }
                else {
                    // currently inside a pair of braces in the format string
                    // found an opening brace
                    if (formatString[index] == openBraceChar) {
                        // check if the brace is escaped
                        if (index < formatString.Length - 1 && formatString[index + 1] == openBraceChar) {
                            // there are escaped braces within the key
                            // this is illegal, throw a format exception
                            throw new FormatException($"Illegal escaped opening braces within a parameter - index: {index}");
                        }
                        else {
                            // not an escaped brace, we have an unexpected opening brace within a pair of braces
                            throw new FormatException($"Unexpected opening brace inside a parameter - index: {index}");
                        }
                    }
                    else if (formatString[index] == closeBraceChar) {
                        // handle case where closing brace is encountered inside braces
                        // don't attempt to check for escaped braces here - always assume the first brace closes the braces
                        // since we cannot have escaped braces within parameters.
                        // set the state to be outside of any braces
                        insideBraces = false;
                        // jump over brace
                        index++;
                        // at this stage, a key is stored in current key that represents the text between the two braces
                        // do a lookup on this key
                        string key = currentKey.ToString();
                        // clear the stringbuilder for the key
                        currentKey.Clear();
                        object outObject;
                        if (!dictionary.TryGetValue(key, out outObject)) {
                            // the key was not found as a possible replacement, throw exception
                            throw new FormatException($"The parameter \"{key}\" was not present in the lookup dictionary");
                        }
                        // we now have the replacement value, add the value to the output string
                        outputString.Append(outObject);
                        // jump to next state
                        continue;
                    } // if }
                    else {
                        // character has no special meaning, add it to the current key
                        currentKey.Append(formatString[index]);
                        // move onto next character
                        index++;
                        continue;
                    } // else
                } // if inside brace
            } // while
            // after the loop, if all braces were balanced, we should be outside all braces
            // if we're not, the input string was misformatted.
            if (insideBraces) {
                throw new FormatException("The format string ended before the parameter was closed.");
            }
            return outputString.ToString();
        }
        /// <summary>
        /// Creates a Dictionary from an objects properties, with the Key being the property's
        /// name and the Value being the properties value (of type object)
        /// </summary>
        /// <param name="properties">An object who's properties will be used</param>
        /// <returns>A <see cref="Dictionary"/> of property values </returns>
        private static Dictionary<string, object> GetPropertiesDictionary(object properties) {
            Dictionary<string, object> values = null;
            if (properties != null) {
                values = new Dictionary<string, object>();
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(properties);
                foreach (PropertyDescriptor prop in props) {
                    values.Add(prop.Name, prop.GetValue(properties));
                }
            }
            return values;
        }
    }
