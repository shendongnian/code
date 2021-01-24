        public static class ListBuilder<T> where T : IBaseInterface
        {
           public static void Build(XmlElement element, 
                                    string elementeName, 
                                    ref List<T> lista, 
                                    Func<XElement,T> ctor)
           {
                 XmlNodeList nl = element.GetElementsByTagName(elementeName);
                 if (nl != null && nl.Count > 0)
                 {
                    for (int i = 0; i < nl.Count; i++)
                    {
                        element = (XmlElement)nl.Item(i);
                        T item = ctor(element);
                        if (!lista.Contains(item))
                           lista.Add(item);
                    }
                 }
            }
        }
