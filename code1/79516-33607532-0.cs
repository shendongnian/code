      private static void PostDeserializedProcess<T>(T deserializedObj)
        {
            var deserializedCallback = deserializedObj as IXmlPostDeserializationCallback;
            if (deserializedCallback != null)
            {
                deserializedCallback.OnXmlDeserialized(deserializedObj);
            }
            else
            {
                // it could be a List of objects 
                // and we need to check for every object in the list
                var collection = deserializedObj as System.Collections.IEnumerable;
                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        PostDeserializedProcess(item);
                    }
                }
            }
        }
