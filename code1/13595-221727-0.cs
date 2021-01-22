    public void Initialize<T>(T obj)
    {
         object[] attributes = obj.GetType().GetCustomAttributes(typeof(SerializableAttribute));
         if(attributes == null || attributes.Length == 0)
              throw new InvalidOperationException("The provided object is not serializable");
    }
