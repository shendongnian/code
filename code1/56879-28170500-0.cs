     private static T[] ArrayDeepCopy<T>(T[] source)
            {
                using (var ms = new MemoryStream())
                {
                    var bf = new BinaryFormatter{Context = new StreamingContext(StreamingContextStates.Clone)};
                    bf.Serialize(ms, source);
                    ms.Position = 0;
                    return (T[]) bf.Deserialize(ms);
                }
            }
