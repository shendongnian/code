        public T Deserialize<T>(string json) where T : someParentClass
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            FieldInfo field = typeof(T).GetField(“Parser”);
            T result = field.FieldType.GetMethod(“ParseFrom”).Invoke(null, new object[]{byteArray});
  
            return result;
        }
        public byte[] Serialize<T>(object obj) where T : someParentClass
        {
                T content = (T)obj;
               
                return T.ToByteArray();
        }
    }
