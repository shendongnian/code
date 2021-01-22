    public static class ExtensionMethods
    {
        public static T XamlClone<T>(this T original)
            where T : class
        {
            if (original == null)
                return null;
            object clone;
            using (var stream = new MemoryStream())
            {
                XamlWriter.Save(original, stream);
                stream.Seek(0, SeekOrigin.Begin);
                clone = XamlReader.Load(stream);
            }
            if (clone is T)
                return (T)clone;
            else
                return null;
        }
    }
