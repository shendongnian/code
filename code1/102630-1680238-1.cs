    namespace MyExtensions
    {
        public static class XElementsExtension
        {
            //Returns an IEnumerable of <PollEvent> having an "<Alert>" child element with attribute "status" == status
            public static IEnumerable<XElement> FindElementsByStatus(this IEnumerable<XElement> list, string status)
            {
                return list.Elements("PollEvent")
                           .Where(x => x.Elements("Alert")
                                        .Any(alert => (string)alert.Attribute("status") == status)
                                 );
            }
        }
    }
