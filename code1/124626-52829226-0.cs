    public static class XmlCompare
    {
        /// <summary>
        /// Compares xml docs without regard to element order, unless the elements are a nested list
        /// </summary>
        /// <param name="primary">Any valid xml</param>
        /// <param name="secondary">Any valid xml</param>
        public static void Compare(string primary, string secondary)
        {
            Compare(XElement.Parse(primary), XElement.Parse(secondary));
        }
        /// <summary>
        /// Compares xml docs without regard to element order, unless the elements are a nested list
        /// </summary>
        /// <param name="primary">Any valid xml</param>
        /// <param name="secondary">Any valid xml</param>
        public static void Compare(XElement primary, XElement secondary)
        {
            // iterate attributes found in primary; compare values
            foreach (XAttribute primaryAttribute in primary.Attributes())
            {
                var secondaryAttribute = secondary.Attribute(primaryAttribute.Name.LocalName);
                if (secondaryAttribute == null)
                {
                    throw new Exception($"Element '{primary.Name.LocalName}' attribute '{primaryAttribute.Name.LocalName}' missing from secondary xml");
                }
                else
                {
                    var primaryValue = primaryAttribute.Value;
                    var secondaryValue = secondaryAttribute.Value;
                    if (primaryValue != secondaryValue)
                        throw new Exception($"Element '{primary.Name.LocalName}' attribute '{primaryAttribute.Name.LocalName}' has an unequal value.  Expected '{primaryValue}', actual '{secondaryValue}'");
                }
            }
            // iterate attributes found in secondary; just ensure all attributes found in the secondary exist in the primary
            foreach (var secondaryAttribute in secondary.Attributes())
            {
                if (primary.Attribute(secondaryAttribute.Name.LocalName) == null)
                    throw new Exception($"Element '{secondary.Name.LocalName}' attribute '{secondaryAttribute.Name.LocalName}' missing from primary xml");
            }
            // iterate elements of primary; compare values
            for (var i = 0; i < primary.Elements().Count(); i++)
            {
                var primaryElement = primary.Elements().Skip(i).Take(1).Single();
                var elementOccursMultipleTimes = primary.Elements(primaryElement.Name.LocalName).Count() > 1;
                if (elementOccursMultipleTimes)
                {
                    // this comparison fails if the sequence of element entries has been altered between the primary
                    // and secondary document, such as sorting a list by name in one document, but sorting by date
                    // in the other.
                    var secondaryElement = secondary.Elements().Skip(i).Take(1).SingleOrDefault();
                    if (secondaryElement == null)
                    {
                        throw new Exception($"Element '{primaryElement.Name.LocalName}' missing from secondary xml");
                    }
                    Compare(primaryElement, secondaryElement);
                }
                else
                {
                    var secondaryElement = secondary.Element(primaryElement.Name.LocalName);
                    if (secondaryElement == null)
                        throw new Exception($"Element '{primaryElement.Name.LocalName}' missing from secondary xml");
                    // to understand recursion, we must first understand recursion
                    Compare(primaryElement, secondaryElement);
                }
            }
            // iterate elements of secondary; just ensure all the elements found in the secondary exist in the primary
            foreach (var secondaryElement in secondary.Elements())
            {
                if (primary.Element(secondaryElement.Name.LocalName) == null)
                    throw new Exception($"Element '{secondaryElement.Name.LocalName}' missing from primary xml");
            }
        }
