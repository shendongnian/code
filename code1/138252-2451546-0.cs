    public static class XPathNavigatorExtensions
    {
        public static bool TrySelectSingleNode(this XPathNavigator navigator,
                                               string xpath,
                                               out XPathNavigator node)
        {
            node = navigator.SelectSingleNode(xpath);
            return (node != null);
        }
    }
