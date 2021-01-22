       [DataContract(Name = "MyClassDTO")]
        public class MyClass
        {
            private string name;
        
            public MyClass()
            {
                Init();
            }
        
            [DataMember]
            public string Name
            {
                get{ return name; }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        name = value;
                    }
                }
            }
        
            private void Init()
            {
                name = "Default Name";
            }
        
            [System.Runtime.Serialization.OnDeserializing]
            private void OnDeserializing(StreamingContext ctx)
            {
                Init();
            }
      }
