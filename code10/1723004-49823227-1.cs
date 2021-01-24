	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Newtonsoft.Json.Converters;
    public static partial class JsonExtensions
    {
        public static JToken ToJToken(this XmlNode node, bool omitRootObject = false, string deserializeRootElementName = null, bool writeArrayAttribute = false)
        {
            // Convert to Linq to JSON JObject
            var settings = new JsonSerializerSettings { Converters = { new XmlNodeConverter { OmitRootObject = omitRootObject, DeserializeRootElementName = deserializeRootElementName, WriteArrayAttribute = writeArrayAttribute } } };
            var root = JToken.FromObject(node, JsonSerializer.CreateDefault(settings));
            return root;
        }
        public static TJToken StripXmlPrefixCharacters<TJToken>(this TJToken root) where TJToken : JToken
        {
            return root.RenameProperties(s => s = s.TrimStart('@').TrimStart('#'));
        }
        // Taken from https://stackoverflow.com/questions/42180161/json-net-custom-jobject-deserialization/42180741#42180741 by dbc
        public static TJToken RenameProperties<TJToken>(this TJToken root, Func<string, string> map) where TJToken : JToken
        {
            if (map == null)
                throw new ArgumentNullException();
            if (root == null)
                return null;
            if (root is JProperty)
            {
                return RenameReplaceProperty(root as JProperty, map, -1) as TJToken;
            }
            else
            {
                foreach (IList<JToken> obj in root.DescendantsAndSelf().OfType<JObject>())
                    for (int i = obj.Count - 1; i >= 0; i--)
                        RenameReplaceProperty((JProperty)obj[i], map, i);
                return root;
            }
        }
        public static IEnumerable<JToken> DescendantsAndSelf(this JToken node)
        {
            if (node == null)
                return Enumerable.Empty<JToken>();
            var container = node as JContainer;
            if (container != null)
                return container.DescendantsAndSelf();
            else
                return new[] { node };
        }
        private static JProperty RenameReplaceProperty(JProperty property, Func<string, string> map, int index)
        {
            // JProperty.Name is read only so it will need to be replaced in its parent.
            if (property == null)
                return null;
            var newName = map(property.Name);
            if (newName == property.Name)
                return property;
            var value = property.Value;
            // Setting property.Value to null on the old property prevents the child JToken hierarchy from getting recursively cloned when added to the new JProperty
            // See https://github.com/JamesNK/Newtonsoft.Json/issues/633#issuecomment-133358110
            property.Value = null;
            var newProperty = new JProperty(newName, value);
            IList<JToken> container = property.Parent;
            if (container != null)
            {
                if (index < 0)
                    index = container.IndexOf(property);
                container[index] = newProperty;
            }
            return newProperty;
        }
    }
