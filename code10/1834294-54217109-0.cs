    using System;
    using System.Collections.Generic;
    using System.IO;
    
    using Amazon.Lambda.Core;
    
    namespace MySerializer
    {
        public class LambdaSerializer : ILambdaSerializer
        {
    
            public LambdaSerializer()
            {
            }
    
    
            public LambdaSerializer(IEnumerable<Newtonsoft.Json.JsonConverter> converters) : this()
            {
                throw new NotSupportedException("Custom serializer with converters not supported.");
            }
    
    
            string GetString(Stream s)
            {
                byte[] ba = new byte[s.Length];
    
                for (int iPos = 0; iPos < ba.Length; )
                {
                    iPos += s.Read(ba, iPos, ba.Length - iPos);
                }
    
                string result = System.Text.ASCIIEncoding.ASCII.GetString(ba);
                return result;
            }
    
    
            public T Deserialize<T>(Stream requestStream)
            {
    			string json = GetString(requestStream);
                T obj = // Your deserialization here
                return obj;
            }
    
    
            public void Serialize<T>(T response, Stream responseStream)
            {
                string json = "Your JSON here";
                StreamWriter writer = new StreamWriter(responseStream);
                writer.Write(json);
    			writer.Flush();
            }
    
        } // public class LambdaSerializer
    
    }
