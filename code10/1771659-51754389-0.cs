    public static class JLinqExtensions
    {
        public static IEnumerable<JToken> Flatten(this JToken token)
        {
            if (token == null)
                yield break;
    
            switch (token.Type)
            {
                case JTokenType.Object:
                    foreach (var property in token.Children<JProperty>())
                    {
                        yield return property;
                        foreach (var item in property.Flatten())
                        {
                            yield return item;
                        }
                    }
                    break;
    
                case JTokenType.Array:
                    foreach (var element in token)
                    {
                        yield return element;
                        foreach (var item in element.Flatten())
                        {
                            yield return item;
                        }
                    }
                    break;
    
                case JTokenType.Property:
                    foreach (var item in ((JProperty)token).Value.Flatten())
                    {
                        yield return item;
                    }
                    break;
    
                default:
                    yield break;
            }
        }
    }
