    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace Utility {
        internal static class ObjectCloner {
            public static T Clone<T>(T obj) {
                using (MemoryStream buffer = new MemoryStream()) {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(buffer, obj);
                    buffer.Position = 0;
                    T temp = (T)formatter.Deserialize(buffer);
                    return temp;
                }
            }
        }
    }
