    /// <summary>
    /// This class can be used when cloning multiple related objects to store cloned/original object relationship.
    /// </summary>
    public class CloningContext
    {
        readonly FieldByType dictionaries = new FieldByType();
        public void RegisterClone<T>(T original, T clone)
        {
            var dictionary = dictionaries.GetValue<Dictionary<T, T>>();
            if (dictionary == null)
            {
                dictionary = new Dictionary<T, T>();
                dictionaries.SetValue(dictionary);
            }
            dictionary[original] = clone;
        }
        public bool TryGetClone<T>(T original, out T clone)
        {
            var dictionary = dictionaries.GetValue<Dictionary<T, T>>();
            return dictionary.TryGetValue(original, out clone);
        }
    }
