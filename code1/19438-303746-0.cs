    private static void ValidateResult(string validationXml, XPathNodeIterator iterator, params string[] excludedElements)
        {
            while (iterator.MoveNext())
            {
                if (!((IList<string>)excludedElements).Contains(iterator.Current.Name))
                {
                    Assert.IsTrue(validationXml.Contains(iterator.Current.Value), "{0} is not the right value for {1}.", iterator.Current.Value, iterator.Current.Name);
                }
            }
        }
