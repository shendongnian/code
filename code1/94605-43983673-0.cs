    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Serialization;
    namespace MyNamespace
    {
        /// <summary>
        /// Provides extension methods for XML-related operations.
        /// </summary>
        public static class XmlSerializerExtension
        {
            /// <summary>
            /// Serializes the specified object and returns the XML document as a string.
            /// </summary>
            /// <param name="obj">The object to serialize.</param>
            /// <param name="namespaces">The <see cref="XmlSerializerNamespaces"/> referenced by the object.</param>
            /// <returns>An XML string that represents the serialized object.</returns>
            public static string Serialize(this object obj, XmlSerializerNamespaces namespaces = null)
            {
                var xser = new XmlSerializer(obj.GetType());
                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb))
                {
                    using (var xtw = new XmlTextWriter(sw))
                    {
                        if (namespaces == null)
                            xser.Serialize(xtw, obj);
                        else
                            xser.Serialize(xtw, obj, namespaces);
                    }
                }
                return sb.ToString().StripNullableEmptyXmlElements();
            }
            /// <summary>
            /// Removes all empty XML elements that are marked with the nil="true" attribute.
            /// </summary>
            /// <param name="input">The input for which to replace the content.    </param>
            /// <param name="compactOutput">true to make the output more compact, if indentation was used; otherwise, false.</param>
            /// <returns>A cleansed string.</returns>
            public static string StripNullableEmptyXmlElements(this string input, bool compactOutput = false)
            {
                const RegexOptions OPTIONS =
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline;
                var result = Regex.Replace(
                    input,
                    @"<\w+\s+\w+:nil=""true""(\s+xmlns:\w+=""http://www.w3.org/2001/XMLSchema-instance"")?\s*/>",
                    string.Empty,
                    OPTIONS
                );
                if (compactOutput)
                {
                    var sb = new StringBuilder();
                    using (var sr = new StringReader(result))
                    {
                        string ln;
                        while ((ln = sr.ReadLine()) != null)
                        {
                            if (!string.IsNullOrWhiteSpace(ln))
                            {
                                sb.AppendLine(ln);
                            }
                        }
                    }
                    result = sb.ToString();
                }
                return result;
            }
        }
    }
