        private static XElement[] GetHits(XDocument x, string modsV3, string givenName, string familyName)
        {
            
            return x.Root.Elements(modsV3 + "mods")
                .MatchNamePart("given", givenName)
                .MatchNamePart("family", familyName).ToArray();
        }
        private static string modsV3 = "whatever";
        private static IEnumerable<XElement> MatchNamePart(this IEnumerable<XElement> records, string type, string givenName)
        {
            return records.Where(rec => rec.Element(modsV3 + "name").
                Elements(modsV3 + "namePart").Any(r1 => HasAttrib(r1, type, givenName)));
        }
        private static bool HasAttrib(XElement element, string attribName, string value)
        {
            return  element.HasAttributes &&
                    element.Attribute("type").Value == attribName &&
                    element.Value == value;
        }
