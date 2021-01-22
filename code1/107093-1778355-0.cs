        public static string TransformXMLToHTML(string inputXml, string xsltString)
        {
            XslCompiledTransform transform = GetAndCacheTransform(xsltString);
            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(inputXml)))
            {
                transform.Transform(reader, null, results);
            }
            return results.ToString();
        }
        private static Dictionary<String, XslCompiledTransform> cachedTransforms = new Dictionary<string, XslCompiledTransform>();
        private static XslCompiledTransform GetAndCacheTransform(String xslt)
        {
            XslCompiledTransform transform;
            if (!cachedTransforms.TryGetValue(xslt, out transform))
            {
                transform = new XslCompiledTransform();
                using (XmlReader reader = XmlReader.Create(new StringReader(xslt)))
                {
                    transform.Load(reader);
                }
                cachedTransforms.Add(xslt, transform);
            }
            return transform;
        }
