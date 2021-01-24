    public static partial class ReportingManipulation
    {
        public static XmlAttributeOverrides GetXMLAttributeOverrides(Type theType, IList<string> propertiesToInlcudeInOrder)
        {
            var allProperties = theType.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance).Select(p => p.Name);
            return GetXMLAttributeOverrides(theType, propertiesToInlcudeInOrder, allProperties);
        }
        // XML Attribute Overrrides
        public static XmlAttributeOverrides GetXMLAttributeOverrides(Type theType, IList<string> propertiesToInlcudeInOrder, IEnumerable<string> allProperties)
        {
            if (propertiesToInlcudeInOrder == null || propertiesToInlcudeInOrder.Count == 0)
                return null;
            var theXMLAttributeOverrides = new XmlAttributeOverrides();
            // To Add In Order
            int counter = 1;
            foreach (var propertyNameToIncludeInOrder in propertiesToInlcudeInOrder)
            {
                // Allocate a fresh instance of XmlAttributes for each property, because we are defining a different
                // XmlElementAttribute for each
                var mainNewXMLAttributes = new XmlAttributes { XmlIgnore = false };
                // Specify the element order XmlElementAttribute and attach to the XmlAttributes
                var theXMLElementAttributeToAdd = new XmlElementAttribute { Order = counter };
                mainNewXMLAttributes.XmlElements.Add(theXMLElementAttributeToAdd);
                // Attach the override XmlElementAttribute to the property propertyNameToIncludeInOrder
                theXMLAttributeOverrides.Add(theType, propertyNameToIncludeInOrder, mainNewXMLAttributes);
                counter++;
            }
            // To Ignore
			// Using System.Linq.Enumerable.Except()
            var propertiesToNotInclude = allProperties.Except(propertiesToInlcudeInOrder);
            var ignoreXMLAttributes = new XmlAttributes { XmlIgnore = true };
            foreach (var propertyNameToNotInlcude in propertiesToNotInclude)
            {
                // Attach the override XmlElementAttribute to the property propertyNameToIncludeInOrder
                // No need to allocate a fresh instance of ignoreXMLAttributes for each, because the instances would all be identical
                theXMLAttributeOverrides.Add(theType, propertyNameToNotInlcude, ignoreXMLAttributes);
            }
            return theXMLAttributeOverrides;
        }
    }
