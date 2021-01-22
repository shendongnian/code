        /// <summary>
        /// Gets the <see cref="XNode" /> into a <c>local-name()</c>, XPath-predicate query.
        /// </summary>
        /// <param name="childElementName">Name of the child element.</param>
        /// <returns></returns>
        public static string GetLocalNameXPathQuery(string childElementName)
        {
            return GetLocalNameXPathQuery(namespacePrefixOrUri: null, childElementName: childElementName, childAttributeName: null);
        }
        /// <summary>
        /// Gets the <see cref="XNode" /> into a <c>local-name()</c>, XPath-predicate query.
        /// </summary>
        /// <param name="namespacePrefixOrUri">The namespace prefix or URI.</param>
        /// <param name="childElementName">Name of the child element.</param>
        /// <returns></returns>
        public static string GetLocalNameXPathQuery(string namespacePrefixOrUri, string childElementName)
        {
            return GetLocalNameXPathQuery(namespacePrefixOrUri, childElementName, childAttributeName: null);
        }
        /// <summary>
        /// Gets the <see cref="XNode" /> into a <c>local-name()</c>, XPath-predicate query.
        /// </summary>
        /// <param name="namespacePrefixOrUri">The namespace prefix or URI.</param>
        /// <param name="childElementName">Name of the child element.</param>
        /// <param name="childAttributeName">Name of the child attribute.</param>
        /// <returns></returns>
        /// <remarks>
        /// This routine is useful when namespace-resolving is not desirable or available.
        /// </remarks>
        public static string GetLocalNameXPathQuery(string namespacePrefixOrUri, string childElementName, string childAttributeName)
        {
            if (string.IsNullOrEmpty(childElementName)) return null;
            if (string.IsNullOrEmpty(childAttributeName))
            {
                return string.IsNullOrEmpty(namespacePrefixOrUri) ?
                    string.Format("./*[local-name()='{0}']", childElementName)
                    :
                    string.Format("./*[namespace-uri()='{0}' and local-name()='{1}']", namespacePrefixOrUri, childElementName);
            }
            else
            {
                return string.IsNullOrEmpty(namespacePrefixOrUri) ?
                    string.Format("./*[local-name()='{0}']/@{1}", childElementName, childAttributeName)
                    :
                    string.Format("./*[namespace-uri()='{0}' and local-name()='{1}']/@{2}", namespacePrefixOrUri, childElementName, childAttributeName);
            }
        }
