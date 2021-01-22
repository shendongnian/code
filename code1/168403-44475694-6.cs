    using Newtonsoft.Json;
    namespace GitRepositoryCreator.Common
    {
        class JObjects
        {
            public static string Get(object p_object)
            {
                return JsonConvert.SerializeObject(p_object);
            }
            internal static T Get<T>(string p_object)
            {
                return JsonConvert.DeserializeObject<T>(p_object);
            }
        }
    }
