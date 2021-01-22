        // Note: This will mutate the specified document.
        private static void ForceTags(XDocument document)
        {
            foreach (XElement childElement in
                from x in document.DescendantNodes().OfType<XElement>()
                where x.IsEmpty
                select x)
            {
                childElement.Value = string.Empty;
            }
        }
