    class ClassA<T> : System.ICloneable where T : System.ICloneable
        {
            public string Name { get; set; }
            public T ObjT { get; set; }
    
            
            public object Clone()
            {
                var clone = new ClassA<T>();
                clone.Name = (string)Name.Clone();
                clone.ObjT = (T)ObjT.Clone();
                return clone;
            }
        }
