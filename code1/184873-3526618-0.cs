    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    public static string ToJson<T>(this T input)
    {
        var serializer = new DataContractJsonSerializer(typeof(T));
        using (var stream = new MemoryStream())
        {
            serializer.WriteObject(stream, input);
            var jsonText = Encoding.UTF8.GetString(stream.ToArray());
            return jsonText;
        }
    }
