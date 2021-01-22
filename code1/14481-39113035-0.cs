    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace DictionaryRuntime
    {
        public class DynamicDictionaryFactory
        {
            /// <summary>
            /// Factory to create dynamically a generic Dictionary.
            /// </summary>
            public IDictionary CreateDynamicGenericInstance(Type keyType, Type valueType)
            {
                //Creating the Dictionary.
                Type typeDict = typeof(Dictionary<,>);
    
                //Creating KeyValue Type for Dictionary.
                Type[] typeArgs = { keyType, valueType };
    
                //Passing the Type and create Dictionary Type.
                Type genericType = typeDict.MakeGenericType(typeArgs);
    
                //Creating Instance for Dictionary<K,T>.
                IDictionary d = Activator.CreateInstance(genericType) as IDictionary;
    
                return d;
    
            }
        }
    }
