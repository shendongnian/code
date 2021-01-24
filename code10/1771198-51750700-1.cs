    class MySerializable
    {
        public Type type { get { return _type; } }
        private Type _type = null;
        private object o;
        private ISerializable s;
        public MySerializable(object obj)
        {
            _type = o.GetType();
            ISerializable ss = obj as ISerializable;
            if (ss != null) s = ss;
            else if (_type.IsPrimitive)
            {
                o = obj;
            }
            else
            {
                throw new Exception("Can only use value types or ISerializables.");
            }
        }
        public override string ToString()
        {
            if (o != null) return o.ToString();
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, s);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
