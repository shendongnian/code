    public static partial class DataContractSerializerExtensions
    {
        public static T FromContract<T>(this XContainer doc, DataContractSerializer serializer = null)
        {
            if (doc == null)
                throw new ArgumentNullException();
            using (var reader = doc.CreateReader())
            {
                return (T)(serializer ?? new DataContractSerializer(typeof(T))).ReadObject(reader);
            }
        }
    }
