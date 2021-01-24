    public class AjaxFileUploadEventArgsConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var args = new AjaxFileUploadEventArgs
            (
                serializer.ConvertItemToTypeOrDefault<string>(dictionary, "FileId"),
                serializer.ConvertItemToTypeOrDefault<AjaxFileUploadState>(dictionary, "State"),
                serializer.ConvertItemToTypeOrDefault<string>(dictionary, "StatusMessage"),
                serializer.ConvertItemToTypeOrDefault<string>(dictionary, "FileName"),
                serializer.ConvertItemToTypeOrDefault<int>(dictionary, "FileSize"), 
                serializer.ConvertItemToTypeOrDefault<string>(dictionary, "ContentType")
            ) 
            { PostedUrl = serializer.ConvertItemToTypeOrDefault<string>(dictionary, "PostedUrl") };
            return args;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(AjaxFileUploadEventArgs) }; }
        }
    }
    public static class JavaScriptSerializerExtensions
    {
        public static T ConvertItemToTypeOrDefault<T>(this JavaScriptSerializer serializer, IDictionary<string, object> dictionary, string key)
        {
            object value;
            if (!dictionary.TryGetValue(key, out value))
                return default(T);
            return serializer.ConvertToType<T>(value);
        }
    }
